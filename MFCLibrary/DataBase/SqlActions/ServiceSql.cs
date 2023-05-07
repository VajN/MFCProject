using DataBase;
using MFCLibrary.DataBase.SqlActions.ServiceSqlActions;
using MFCLibrary.Models;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ServiceSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void AddService(Service service)
        {
            SqlAddService.AddService(db, service);
        }
        internal void UpdateService(string updateRow, object newValue, int id)
        {
            SqlUpdateService.UpdateService(db, updateRow, newValue, id);
        }
        internal void DeleteService(int deleteId)
        {
            SqlDeleteService.DeleteService(db, deleteId);
        }
        internal bool CheckService(string checkRow, object checkValue)
        {
            return SqlCheckService.CheckService(db, checkRow, checkValue);
        }
        internal string TakeValueService(string row, string checkRow, object checkValue)
        {
            return SqlTakeValueService.TakeValueService(db, row, checkRow, checkValue);
        }
    }
}
