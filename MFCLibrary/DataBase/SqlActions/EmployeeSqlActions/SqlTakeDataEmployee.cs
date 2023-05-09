using DataBase;
using System.Data.SQLite;

namespace MFCLibrary.DataBase.SqlActions.EmployeeSqlActions
{
    internal static class SqlTakeDataEmployee
    {
        internal static List<string[]> TakeDataEmployee(MFCDataBase db)
        {
            List<string[]> result = new List<string[]>();
            string temp = "";

            db.command = new SQLiteCommand($"SELECT * FROM {db.EmployeeTableName}", db.connection);
            SQLiteDataReader reader = db.command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    for (int i = 0; true; i++)
                        temp += $"{reader.GetValue(i)}/";
                }
                catch
                {
                    result.Add(temp.Split("/"));
                    temp = "";
                }
            }
            reader.Close();
            return result;
        }
    }
}
