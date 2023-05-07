using DataBase;
using MFCLibrary.DataBase.SqlActions.ClientSqlActions;
using MFCLibrary.DataBase.SqlActions.EmployeeSqlActions;
using MFCLibrary.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Xml;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class EmployeeSql
    {
        MFCDataBase db { get; } = new MFCDataBase();
        internal void AddEmployee(Employee employee)
        {
            SqlAddEmployee.AddEmployee(db, employee);
        }
        internal string TakeValueEmployee(string row, string checkRow, object checkValue)
        {
            return SqlTakeValueEmployee.TakeValueEmployee(db, row, checkRow, checkValue);
        }
        internal bool CheckEmployee(string checkRow, object checkValue)
        {
            return SqlCheckEmployee.CheckEmployee(db, checkRow, checkValue);
        }
    }
}
