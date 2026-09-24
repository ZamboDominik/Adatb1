using MySqlConnector;
namespace Adatb1
{
    internal class Program
    {
        const string connString = "Server=localhost;Port=32768;Database=sys;User=root;Password=Teszt123;";
        static void Main(string[] args)
        {
            var connection = new MySqlConnection(connString);
            connection.Open();
            string createSql = @"
            
            CREATE TABLE IF NOT EXISTS Users (
            Id INT PRIMARY KEY AUTO_INCREMENT,
            Name VARCHAR(100),
            Email VARCHAR(100)
            );";
            var createCmd = new MySqlCommand(createSql, connection);
            createCmd.ExecuteNonQuery();
            string insertSql = "INSERT INTO Users (Name, Email) VALUES ('Teszt Elek', 'elek@teszt.hu');";
            var insertCmd = new MySqlCommand(insertSql, connection);
            insertCmd.ExecuteNonQuery();

            string selectSql = "SELECT Id, Name, Email FROM Users;";
            var selectCmd = new MySqlCommand(selectSql, connection);
            var reader = selectCmd.ExecuteReader();

            Console.WriteLine("\nRekordok:");
            while (reader.Read())
            {
                Console.WriteLine($"[{reader["Id"]}] {reader["Name"]} - {reader["Email"]}");
            }
            
            reader.Close();
            connection.Close();

        }
    }
}
