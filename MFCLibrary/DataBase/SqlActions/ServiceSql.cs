using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions.ServiceSqlActions;

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
        internal List<string[]> TakeDataService()
        {
            return SqlTakeDataService.TakeDataService(db);
        }
        internal string TakeValueService(string row, string checkRow, object checkValue)
        {
            return SqlTakeValueService.TakeValueService(db, row, checkRow, checkValue);
        }
        internal bool CheckService(string checkRow, object checkValue)
        {
            return SqlCheckService.CheckService(db, checkRow, checkValue);
        }
    }
}
