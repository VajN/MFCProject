using DataBase;
using MFCLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ServicingSqlActions
{
    internal static class SqlAddServicing
    {
        internal static void AddServicing(MFCDataBase db, Servicing servicing)
        {
            db.command.CommandText = $"INSERT INTO {db.ServicingTableName} (employeeId, windowNumber, date, time, serviceName, clientId, numberQueue) VALUES (\"{servicing.employeeId}\",\"{servicing.windowNumber}\",\"{DateOnly.FromDateTime(servicing.dateTime)}\",\"{TimeOnly.FromDateTime(servicing.dateTime)}\",\"{servicing.serviceName}\", \"{servicing.clientId}\",\"{servicing.numberQueue}\")";
            db.command.ExecuteNonQuery();
        }
    }
}
