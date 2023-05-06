using DataBase;
using MFCLibrary.Models;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ServiceSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void AddService(Service service)
        {
            db.command.CommandText = $"INSERT INTO {db.ServiceTableName} (name, isUse) VALUES (\"{service.name}\", 0)";
            db.command.ExecuteNonQuery();
        }
    }
}
