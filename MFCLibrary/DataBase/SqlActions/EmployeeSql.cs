using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions.EmployeeSqlActions;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class EmployeeSql
    {
        MFCDataBase db { get; } = new MFCDataBase();
        internal void AddEmployee(Employee employee)
        {
            SqlAddEmployee.AddEmployee(db, employee);
        }
        internal void DeleteEmployee(int deleteId)
        {
            SqlDeleteEmployee.DeleteEmployee(db, deleteId);
        }
        internal void UpdateEmployee(string updateRow, object newValue, int id)
        {
            SqlUpdateEmployee.UpdateEmployee(db, updateRow, newValue, id);
        }
        internal List<string[]> TakeDataEmployee()
        {
            return SqlTakeDataEmployee.TakeDataEmployee(db);
        }
        internal string TakeValueEmployee(string row, string checkRow, object checkValue)
        {
            return SqlTakeValueEmployee.TakeValueEmployee(db, row, checkRow, checkValue);
        }
        internal bool CheckEmployee(string checkRow, object checkValue)
        {
            return SqlCheckEmployee.CheckEmployee(db, checkRow, checkValue);
        }
    }
}
