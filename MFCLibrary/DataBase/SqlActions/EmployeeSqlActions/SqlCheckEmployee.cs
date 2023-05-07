using DataBase;
using System.Data.SQLite;

namespace MFCLibrary.DataBase.SqlActions.EmployeeSqlActions
{
    internal static class SqlCheckEmployee
    {
        internal static bool CheckEmployee(MFCDataBase db, string checkRow, object CheckValue)
        {
            db.command.CommandText = $"SELECT {checkRow} FROM {db.EmployeeTableName}";
            SQLiteDataReader reader = db.command.ExecuteReader();
            while (reader.Read())
            {
                if (CheckValue is string)
                {
                    if (reader.GetString(0) == (string)CheckValue)
                    {
                        reader.Close();
                        return true;
                    }
                }
                else
                {
                    if (reader.GetInt32(0) == (int)CheckValue)
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            reader.Close();
            return false;
        }
    }
}
