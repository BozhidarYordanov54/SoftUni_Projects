using _01._Initial_Setup.SQL_Queries;
using System.Data.SqlClient;

// 1. Connection string
const string _connectionString = @"Server = DESKTOP-TB54MG6\SQLEXPRESS01; 
                                   Database = MinionsDB; 
                                   Integrated Security = True"; // 1. Server Name, 2. Database Name, 3. Windows AUTH Token

// 2. SqlConnection
using SqlConnection sqlConnection = new SqlConnection(_connectionString);
sqlConnection.Open();

// 3.Sql Command
using SqlCommand getVillainsCommand = new SqlCommand(SqlQuries.GetVilliansWithNumberOfMinions, sqlConnection);

// 4. Sql Data Reader
using SqlDataReader sqlDataReader = getVillainsCommand.ExecuteReader();

while (sqlDataReader.Read())
{
    Console.WriteLine($"{sqlDataReader["Name"]} - {sqlDataReader["TotalMinions"]}");
}