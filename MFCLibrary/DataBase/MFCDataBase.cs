using System.Data.SqlClient;
using System.Data.SQLite;


namespace DataBase
{
    internal class MFCDataBase
    {
        internal SQLiteConnection connection = new SQLiteConnection();
        internal SQLiteCommand command = new SQLiteCommand();

        internal string DatabaseName { get; } = "MFCLITE";
        internal string EmployeeTableName { get; } = "Employee";
        internal string DelEmployeeTableName { get; } = "DelEmployee";
        internal string ClientTableName { get; } = "Client";
        internal string ServiceTableName { get; } = "Service";
        internal string ServicingTableName { get; } = "Servicing";
        internal string AutorizedServicingTableName { get; } = "AutorizedServicing";

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

            CreateClientTable();
            CreateServiceTable();
            CreateEmployeeTable();
            CreateServicingTable();
            CreateDelEmployeeTable();
            CreateAuthorizedServicingTable();
        }

        private void CreateEmployeeTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{EmployeeTableName}] ([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullnameEmployee] TEXT, [birthday] TEXT, [windowNumber] TEXT);"
            }; 
            command.ExecuteNonQuery();
        }
        private void CreateClientTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{ClientTableName}]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullnameClient] TEXT, [passport] TEXT, [isAuthorized] BIT);"
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
                CommandText = $"CREATE TABLE IF NOT EXISTS [{ServicingTableName}]([employeeId] INT, [windowNumber] TEXT, [date] TEXT, [time] TEXT, [serviceName] TEXT, [clientId] INT, [numberQueue] TEXT);"
            };
            command.ExecuteNonQuery();
        }
        private void CreateAuthorizedServicingTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{AutorizedServicingTableName}]([employeeId] INT, [windowNumber] TEXT, [date] TEXT, [time] TEXT, [serviceName] TEXT, [clientId] INT);"
            };
            command.ExecuteNonQuery();
        }
        private void CreateDelEmployeeTable()
        {
            command = new SQLiteCommand(connection)
            {
                CommandText = $"CREATE TABLE IF NOT EXISTS [{DelEmployeeTableName}]([id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, [fullnameEmployee] TEXT, [birthday] TEXT, [windowNumber] INT);"
            };
            command.ExecuteNonQuery();
        }
    }
}