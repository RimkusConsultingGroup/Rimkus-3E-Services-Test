using Dapper;
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;

namespace TE3EConnect.e3eMapper
{
    public class e3eLookup
    {
        private static string connectionString = @"Data Source=|DataDirectory|concurLookup.sdf;Persist Security Info=False";
        private static SqlCeConnection _sqlConnection;

        private static string expenseTypeSql = @"
            SELECT [expenseType]
                  ,[glCode]
              FROM [ExpenseType]
              WHERE [expenseType] = @expenseType
        ";

        private static string stateSql = @"
            SELECT [code]
                  ,[name]
              FROM [State]
              WHERE [name] = @statename
        ";

        private static string glDepartmentSql = @"
            SELECT [glDeptCd]
                  ,[glDeptDesc]
              FROM [GLDepartment]
              WHERE [glDeptDesc] = @glDeptDesc
        ";

        private static string employeeSql = @"
            SELECT [employeeName]
                  ,[department]
                  ,[deptCode]
              FROM [Employee]
              WHERE [employeeName] LIKE '%@employeeName%'
        ";

        private static string costTypeSql = @"
            SELECT [costtype]
                  ,[glCode]
              FROM [CostType]
              WHERE [costtype] = @costtype
        ";

        private static string voucherInsertSql = @"

            INSERT INTO [Voucher]
                       ([vchrType]
                       ,[invNum]
                       ,[tranDate]
                       ,[invDate]
                       ,[amount]
                       ,[created])
                 VALUES
                       ('{0}'
                       ,'{1}'
                       ,'{2}'
                       ,'{3}'
                       ,'{4}'
                       ,GETDATE());
            ";

        public static void AddVoucher(CommittedVoucher cVchr)
        {
            using (_sqlConnection = OpenConnection())
            {
                voucherInsertSql = string.Format(voucherInsertSql, cVchr.vchrType, cVchr.invNum, cVchr.tranDate, cVchr.invDate, cVchr.amount);

                _sqlConnection.Execute(voucherInsertSql);
            }
        }

        public static CostType GetCostType(string _costtype)
        {
            CostType ctype = null;

            using (_sqlConnection = OpenConnection())
            {
                var results = _sqlConnection.Query<CostType>(costTypeSql, new { costtype = _costtype });

                if (results.Count() > 0)
                    ctype = results.First();
            }

            return ctype;
        }

        //public static Employee GetEmployee(string fullName)
        //{
        //    Employee emp = null;

        //    using (_sqlConnection = OpenConnection())
        //    {
        //        string empSql = employeeSql;
        //        empSql = empSql.Replace("@employeeName", fullName);
        //        var results = _sqlConnection.Query<Employee>(empSql);

        //        if (results.Count() > 0)
        //            emp = results.First();
        //    }

        //    return emp;
        //}

        public static State GetStateCode(string name)
        {
            State state = null;

            using (_sqlConnection = OpenConnection())
            {
                string stSql = stateSql;
                stSql = stSql.Replace("@statename", name);
                var results = _sqlConnection.Query<State>(stSql);

                if (results.Count() > 0)
                    state = results.First();
            }

            return state;
        }

        public static ExpenseType GetExpenseType(string expType)
        {
            ExpenseType expenseType = null;

            using (_sqlConnection = OpenConnection())
            {
                var results = _sqlConnection.Query<ExpenseType>(expenseTypeSql, new { expenseType = expType });

                if (results.Count() > 0)
                    expenseType = results.First();
            }

            return expenseType;
        }

        public static GLDepartment GetGLDepartment(string glDesc)
        {
            GLDepartment gLDepartment = null;

            using (_sqlConnection = OpenConnection())
            {
                var results = _sqlConnection.Query<GLDepartment>(glDepartmentSql, new { glDeptDesc = glDesc });

                if (results.Count() > 0)
                    gLDepartment = results.First();
            }

            return gLDepartment;
        }

        private static SqlCeConnection OpenConnection()
        {
            _sqlConnection = new SqlCeConnection(connectionString);
            _sqlConnection.Open();
            return _sqlConnection;
        }

        private static void ClosedConnection()
        {
            if (_sqlConnection.State != ConnectionState.Closed)
                _sqlConnection.Close();
        }
    }

    public class Employee
    {
        public string employeeName { get; set; }
        public string department { get; set; }
        public int deptCode { get; set; }
    }

    public class CostType
    {
        public string costType { get; set; }
        public int glCode { get; set; }
    }

    public class ExpenseType
    {
        public string expenseType { get; set; }
        public int glCode { get; set; }
    }

    public class State
    {
        public string name { get; set; }
        public int code { get; set; }
    }

    public class GLDepartment
    {
        public int glDeptCd { get; set; }

        public string glDeptDesc { get; set; }
    }

    public class CommittedVoucher
    {
        public string vchrType { get; set; }
        public string invNum { get; set; }
        public DateTime tranDate { get; set; }
        public DateTime invDate { get; set; }
        public string amount { get; set; }
    }
}