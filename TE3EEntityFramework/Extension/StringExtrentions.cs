using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace TE3EEntityFramework.Extension
{
    public static class StringExtrentions
    {
        /// <summary>
        /// String to Base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static void TrimAllStrings<TSelf>(this TSelf obj)
        {
            if (obj != null)
            {
                if (obj is IEnumerable)
                {
                    foreach (var listItem in obj as IEnumerable)
                    {
                        listItem.TrimAllStrings();
                    }
                }
                else
                {
                    BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

                    foreach (PropertyInfo p in obj.GetType().GetProperties(flags))
                    {
                        Type currentNodeType = p.PropertyType;
                        if (currentNodeType == typeof(String))
                        {
                            string currentValue = (string)p.GetValue(obj, null);
                            if (currentValue != null)
                            {
                                p.SetValue(obj, currentValue.Trim(), null);
                            }
                        }
                        // see http://stackoverflow.com/questions/4444908/detecting-native-objects-with-reflection
                        else if (currentNodeType != typeof(object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
                        {
                            p.GetValue(obj, null).TrimAllStrings();
                        }
                    }
                }
            }
        }

        //public static object TrimAllStrings(this object obj)
        //{
        //    var stringProperties = obj.GetType().GetProperties()
        //                  .Where(p => p.PropertyType == typeof(string));

        //    foreach (var stringProperty in stringProperties)
        //    {
        //        string currentValue = (string)stringProperty.GetValue(obj, null);
        //        stringProperty.SetValue(obj, currentValue?.Trim(), null);
        //    }

        //    return obj;
        //}


        /// <summary>
        /// Base64 to String
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string XMLEncode(this string value)
        {
            return HttpUtility.HtmlEncode(value);
        }
        public static string XMLFixesEncode(this string str)
        {
            string enc = System.Security.SecurityElement.Escape(str);
            string[] splitlist = new string[] { "&gt;" };
            Regex rxEndTag = new Regex(@"&lt;/(?<tag>[\w ""]{1,})&gt;");
            MatchCollection mc = rxEndTag.Matches(enc);

            foreach (Match m in mc)
            {
                //Console.WriteLine(m.Groups[1].Value);
                string item = m.Groups["tag"].Value;
                enc = enc.Replace(String.Format("&lt;/{0}&gt;", item), String.Format("</{0}>", item))
                    .Replace(String.Format("&lt;{0}&gt;", item), String.Format("<{0}>", item));
            }
            //var xmlnslist = enc.Split(splitlist, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < xmlnslist.Length; i++)
            //{
            //    if (xmlnslist[i].Contains("xmln"))
            //    {
            //        xmlnslist[i] = HttpUtility.HtmlDecode($"{xmlnslist[i]}&gt;");
            //    }
            //}
            //enc = string.Join("", xmlnslist);
            enc = enc.Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">");
            return enc;
        }
        public static string SQLSafe(this string value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value.Replace("'", "''");
            }
        }
        public static int? ToInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                if (int.TryParse(value, out int result))
                {
                    return result;
                }
                return null;
            }
        }
        public static bool? ToBool(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                if (bool.TryParse(value, out bool result))
                {
                    return result;
                }
                return null;
            }
        }
        public static decimal? ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                if (decimal.TryParse(value, out decimal result))
                {
                    return result;
                }
                return null;
            }
        }
        public static DateTime? ToDateTime(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                if (DateTime.TryParse(value, out DateTime result))
                {
                    return result;
                }
                return null;
            }
        }

        public static string IfNullOrEmptyUseThis(this string value, string newValue = "")
        {
            return string.IsNullOrWhiteSpace(value) ? newValue : value;
        }

        public static FullNameComponents ParseFullname(this string fullname)
        {
            FullNameComponents fullNameParts = new FullNameComponents();
            List<string> updatedFullname = new List<string>();

            if (string.IsNullOrEmpty(fullname))
            {
                return fullNameParts;
            }
            // Disabling Salutation Extraction for now as it replace data between the strings and right now we are not handling salutation in NBI
            //if (fullname.Contains("Mr."))
            //{
            //    fullname = fullname.Replace("Mr.", "");
            //    fullNameParts.Salutation = "Mr.";
            //}
            //else if (fullname.Contains("Mr"))
            //{
            //    fullname = fullname.Replace("Mr", "");
            //    fullNameParts.Salutation = "Mr";
            //}
            //else if (fullname.Contains("Mrs."))
            //{
            //    fullname = fullname.Replace("Mrs.", "");
            //    fullNameParts.Salutation = "Mrs.";
            //}
            //else if (fullname.Contains("Mrs"))
            //{
            //    fullname = fullname.Replace("Mrs", "");
            //    fullNameParts.Salutation = "Mrs";
            //}
            //else if (fullname.Contains("Ms."))
            //{
            //    fullname = fullname.Replace("Ms.", "");
            //    fullNameParts.Salutation = "Ms.";
            //}
            //else if (fullname.Contains("Ms"))
            //{
            //    fullname = fullname.Replace("Ms", "");
            //    fullNameParts.Salutation = "Ms";
            //}
            //else if (fullname.Contains("Dr"))
            //{
            //    fullname = fullname.Replace("Dr", "");
            //    fullNameParts.Salutation = "Dr";
            //}
            //else if (fullname.Contains("Dr."))
            //{
            //    fullname = fullname.Replace("Dr.", "");
            //    fullNameParts.Salutation = "Dr.";
            //}
            fullNameParts.Salutation = "";
            updatedFullname = fullname.Split(' ').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            var nameLength = updatedFullname.Count();
            if (nameLength == 0)
            {
                fullNameParts.Firstname = string.Empty;
                fullNameParts.Lastname = string.Empty;
            }
            else if (nameLength == 1)
            {
                fullNameParts.Firstname = updatedFullname.FirstOrDefault();
                fullNameParts.Lastname = string.Empty;
            }
            else if (nameLength == 2)
            {
                fullNameParts.Firstname = updatedFullname.FirstOrDefault();
                fullNameParts.Lastname = updatedFullname.LastOrDefault();
            }
            else if (nameLength >= 3)
            {
                fullNameParts.Firstname = string.Join(" ", updatedFullname.Take(2).ToList());
                fullNameParts.Lastname = string.Join(" ", updatedFullname.Skip(2).ToList());
            }
            return fullNameParts;
        }

        public static string MakeSafeForFileName(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                str = str.Replace(c, '-');
            }
            return str;
        }
        public static string TrimToLength(this string str, int len)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= len)
            {
                return str;
            }
            return str.Substring(0, len);
        }
        public static string CombineWith(this string str, string combineWith)
        {
            var temp = $"{str} {combineWith}".Trim();
            if (string.IsNullOrEmpty(temp))
            {
                return null;
            }
            else
            {
                return temp;
            }
        }
    }


    public class FullNameComponents
    {
        public string Salutation { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
    }
}
