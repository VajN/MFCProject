using DataBase;
using MFCLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ServiceSqlActions
{
    internal static class SqlAddService
    {
        internal static void AddService(MFCDataBase db, Service service)
        {
            db.command.CommandText = $"INSERT INTO {db.ServiceTableName} (name, isUse) VALUES (\"{service.name}\", false)";
            db.command.ExecuteNonQuery();
        }
    }
}
