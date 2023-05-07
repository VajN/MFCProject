using DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MFCLibrary.DataBase.SqlActions.ServiceSqlActions
{
    internal static class SqlUpdateService
    {
        static internal void UpdateService(MFCDataBase db, string updateRow, object newValue, int id)
        {
            db.command = new SQLiteCommand($"UPDATE {db.ServiceTableName} SET {updateRow}=\"{newValue}\" WHERE id={id}", db.connection);
            db.command.ExecuteNonQuery();
        }
    }
}
