using DataBase;
using MFCLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.EmployeeSqlActions
{
    internal static class SqlAddEmployee
    {
        internal static void AddEmployee(MFCDataBase db, Employee employee)
        {
            db.command.CommandText = $"INSERT INTO {db.EmployeeTableName} (fullnameEmployee, birthday, windowNumber) VALUES (\"{employee.fullnameEmployee}\",\"{employee.birthday}\",\"{employee.windowNumber}\")";
            db.command.ExecuteNonQuery();
        }
    }
}
