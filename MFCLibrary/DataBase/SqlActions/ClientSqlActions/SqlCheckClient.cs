using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ClientSqlActions
{
    internal static class SqlCheckClient
    {
        internal static bool CheckClient(MFCDataBase db, string checkRow, object CheckValue)
        {
            db.command.CommandText = $"SELECT {checkRow} FROM {db.ClientTableName}";
            SQLiteDataReader reader = db.command.ExecuteReader();
            while (reader.Read())
            {
                if(CheckValue is string)
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
