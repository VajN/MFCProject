using DataBase;
using MFCLibrary.DataBase.SqlActions.ServicingSqlActions;
using MFCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ServicingSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void AddServicing(Servicing servicing)
        {
            SqlAddServicing.AddServicing(db, servicing);
        }
        internal List<string> TakeRowServicing(string row)
        {
            return SqlTakeRowServicing.TakeRowServicing(db, row);
        }
    }
}
