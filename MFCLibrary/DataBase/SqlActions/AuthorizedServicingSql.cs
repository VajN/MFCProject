using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions.AuthorizedServisingSqlActions;
using MFCLibrary.DataBase.SqlActions.ServicingSqlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class AuthorizedServicingSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void AddAuthorizedServicing(AuthorizedServicing authorizedServicing)
        {
            SqlAddAuthorizedServicing.AddAuthorizedServicing(db, authorizedServicing);
        }
        internal bool CheckAuthorizedServicing(string checkRow, object CheckValue)
        {
            return SqlCheckAuthorizedServicing.CheckAuthorizedServicing(db, checkRow, CheckValue);
        }
        internal List<string[]> TakeDataAuthorizedServicing()
        {
            return SqlTakeDataAuthorizedServicing.TakeDataServicing(db);
        }
    }
}
