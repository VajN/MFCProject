using DataBase;
using MFCLibrary.Data.Models;

namespace MFCLibrary.DataBase.SqlActions.AuthorizedServisingSqlActions
{
    internal static class SqlAddAuthorizedServicing
    {
        internal static void AddAuthorizedServicing(MFCDataBase db, AuthorizedServicing authorizedServicing)
        {
            db.command.CommandText = $"INSERT INTO {db.AutorizedServicingTableName} (employeeId, windowNumber, date, time, serviceName, clientId) VALUES (\"{authorizedServicing.employeeId}\",\"{authorizedServicing.windowNumber}\",\"{DateOnly.FromDateTime(authorizedServicing.dateTime)}\",\"{TimeOnly.FromDateTime(authorizedServicing.dateTime)}\",\"{authorizedServicing.serviceName}\", \"{authorizedServicing.clientId}\")";
            db.command.ExecuteNonQuery();
        }
    }
}
