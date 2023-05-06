using DataBase;
using MFCLibrary.Models;
using System.Data;
using System.Data.SQLite;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class EmployeeSql
    {
        MFCDataBase db { get; } = new MFCDataBase();
        internal void AddEmployee(Employee employee)
        {
            db.command.CommandText = $"INSERT INTO {db.EmployeeTableName} (fullnameEmployee, birthday, windowNumber) VALUES (\"{employee.fullnameEmployee}\",\"{employee.birthday}\",\"{employee.windowNumber}\")";
            db.command.ExecuteNonQuery();
        }
        internal bool CheckEmployee(int windowNumber)
        {
            db.command.CommandText = $"SELECT windowNumber FROM {db.EmployeeTableName}";
            SQLiteDataReader reader = db.command.ExecuteReader();
            while(reader.Read())
            {
                if (reader.GetInt32(0) == windowNumber)
                {
                    reader.Close();
                    return true;
                }    
            }
            reader.Close();
            return false;
        }
    }
}
