using DataBase;
using MFCLibrary.DataBase.SqlActions.DelEmployeeSqlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class DelEmployeeSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void TransferDelEmployee(int id)
        {
            SqlTransferDelEmployee.TransferDelEmployee(db, id);
        }
    }
}
