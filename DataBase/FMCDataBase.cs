using System.Data.SqlClient;
using System.Data.SQLite;
using DataBase.Entities;


namespace DataBase
{
    public class MFCDataBase
    {
        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command = new SQLiteCommand();

        string DatabaseName { get; } = "MFCLITE";
        string EmployeeTableName { get; } = "Employee";
        string ClientTableName { get; } = "Client";
        string ServiceTableName { get; } = "Service";
        string ServicingTableName { get; } = "Servicing";
        string DelEmployeeTableName { get; } = "DelEmployee";

        public MFCDataBase()
        {
            try
            {
                connection = new SQLiteConnection($"Data Source = {DatabaseName}.db;Version=3; FailIfMissing=False");
                connection.Open();
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }

            CreateEmployeeTable();
            CreateClientTable();
            CreateServiceTable();
            CreateServicingTable();
            CreateDelEmployeeTable();
        }

        private void CreateEmployeeTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{EmployeeTableName}] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullnameEmployee] TEXT, [birthday] TEXT, [windowNumber] INT);"
            }; 
            command.ExecuteNonQuery();
        }
        private void CreateClientTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{ClientTableName}]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullnameClient] TEXT, [passport] TEXT);"
            };
            command.ExecuteNonQuery();
        }
        private void CreateServiceTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{ServiceTableName}]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [name] TEXT, [isUse] BIT);"
            };
            command.ExecuteNonQuery();
        }
        private void CreateServicingTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{ServicingTableName}]([employeeId] INT, [windowNumber] INT, [date] TEXT, [time] TEXT, [serviceName] TEXT, [clientId] INT, [numberQueue] TEXT);"
            };
            command.ExecuteNonQuery();
        }
        private void CreateDelEmployeeTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{DelEmployeeTableName}] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullnameEmployee] TEXT, [birthday] TEXT, [windowNumber] INT);"
            };
            command.ExecuteNonQuery();
        }

    }
}