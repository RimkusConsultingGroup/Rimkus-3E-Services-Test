using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using Palit.AspNetCore.JsonPatch.Extensions.Generate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Data.Te3e.CMS.Definition;

namespace TE3EEntityFramework.Extension
{
    public static class JsonPatchHelper
    {

        public static Dictionary<string, List<Operation>> FindAndGroupChildUpdateOps(this List<Operation> operations, string childPath)
        {
            var temp = operations.Where(x => x.path.ToLower().Contains(childPath.ToLower()) && x.OperationType == OperationType.Replace).GroupBy(x => x.path.Split('/')[2])
                .ToDictionary(x => x.Key, x => x.Select(y => new Operation()
                {
                    from = y.from,
                    op = y.op,
                    path = $"/{y.path.Split('/')[3]}",
                    value = y.value
                }).ToList());
            return temp;
        }
        public static List<Operation> FindChilds(this List<Operation> operations, string childPath, OperationType operationType)
        {
            return operations.Where(x => x.path.ToLower().Contains(childPath.ToLower()) && x.OperationType == operationType).ToList();
        }
        public static void RemoveChilds(this List<Operation> operations, string childPath)
        {
            operations.RemoveAll(x => x.path.ToLower().Contains(childPath.ToLower()));
        }
        public static void RemoveChilds(this List<Operation> operations, string childPath, OperationType operationType)
        {
            operations.RemoveAll(x => x.path.ToLower().Contains(childPath.ToLower()) && x.OperationType == operationType);
        }
        public static void RemoveEmptyChanges(this List<Operation> operations)
        {
            operations.RemoveAll(x => (x.from == null && x.value.ToString() == "") || (x.value == null && x.from.ToString() == ""));
        }
        public static List<Operation> CompareAndGenerate<T>(T oldObj, T newObj) where T : class
        {
            var generator = new JsonPatchDocumentGenerator();
            var ops = generator.Generate(oldObj, newObj).Operations;
            ops.RemoveEmptyChanges();
            return ops;
        }
        public static List<Operation> CompareListAndGenerate<T>(List<T> oldList, List<T> newList, string listName, string keyToCompare) where T : class
        {
            List<Operation> ops = new List<Operation>();
            if (oldList == null)
            {
                oldList = new List<T>();
            }
            if (newList == null)
            {
                newList = new List<T>();
            }

            var oldListKeys = oldList.Select(x => x.GetPropValue(keyToCompare)).ToList();
            var newListKeys = newList.Select(x => x.GetPropValue(keyToCompare)).ToList();


            var toBeAdded = newListKeys.Where(x => !oldListKeys.Contains(x)).ToList();

            var toBeDeleted = oldListKeys.Where(x => !newListKeys.Contains(x)).ToList();

            var toBeUpdated = oldListKeys.Where(x => newListKeys.Contains(x)).ToList();

            // Add
            newList.Where(x => toBeAdded.Contains(x.GetPropValue(keyToCompare))).ToList()
                .ForEach(x =>
            {
                ops.Add(new Operation()
                {
                    op = OperationType.Add.ToString().ToLower(),
                    path = $"/{listName}/-",
                    value = x
                });
                newList.Remove(x);
            });

            // Remove
            oldList.Where(x => toBeDeleted.Contains(x.GetPropValue(keyToCompare))).ToList()
                .ForEach(x =>
            {
                ops.Add(new Operation()
                {
                    op = OperationType.Remove.ToString().ToLower(),
                    path = $"/{listName}/{x.GetPropValue(keyToCompare)}/",
                    value = null
                });
                oldList.Remove(x);
            });

            // Update
            oldList.Where(x => toBeUpdated.Contains(x.GetPropValue(keyToCompare))).ToList()
                .ForEach(oldObj =>
                {
                    var keyValue = oldObj.GetPropValue(keyToCompare);

                    var newObj = newList.FirstOrDefault(x => x.GetPropValue(keyToCompare) == keyValue);
                    var diffOps = CompareAndGenerate(oldObj, newObj);
                    foreach (var item in diffOps)
                    {
                        item.path = $"/{listName}/{keyValue}{item.path}/";
                    }
                    ops.AddRange(diffOps);
                    newList.Remove(newObj);
                    oldList.Remove(oldObj);
                });
            return ops;
        }
        public static string GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null)?.ToString();
        }

        public static void ApplyPatch<T>(this List<Operation> operations, T obj)
        {
            JsonPatchDocument patchDocument = new JsonPatchDocument();
            patchDocument.Operations.AddRange(operations.AsEnumerable());
            patchDocument.ApplyTo(obj);
        }
    }
}
