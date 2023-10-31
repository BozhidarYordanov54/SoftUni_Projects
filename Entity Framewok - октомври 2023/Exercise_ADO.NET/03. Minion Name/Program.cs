using _03._Minion_Name.SqlQueries;
using System.Data.SqlClient;

const string _connectionString = @"Server = DESKTOP-TB54MG6\SQLEXPRESS01; Database = MinionsDB; Integrated Security = True"; // 1. Server Name, 2. Database Name, 3. Windows AUTH Token

using SqlConnection sqlConnection = new SqlConnection(_connectionString);

await GetOrderedMinionsByVillainId(1, sqlConnection);
await GetOrderedMinionsByVillainId(8, sqlConnection);

static async Task GetOrderedMinionsByVillainId(int id, SqlConnection sqlConnection)
{
    sqlConnection.Open();

    using SqlCommand command = new SqlCommand(SqlQueries.GetVillianById, sqlConnection);
    command.Parameters.AddWithValue("@Id", id);
    var result = await command.ExecuteScalarAsync();

    if (result is null)
    {
        await Console.Out.WriteLineAsync($"No villain with ID {id} exists in the database.");
    }
    else
    {
        await Console.Out.WriteLineAsync($"Villain: {result}");

        using SqlCommand commandGetMinionData = new SqlCommand(SqlQueries.GetOrderedMinionsByVillainId, sqlConnection);
        commandGetMinionData.Parameters.AddWithValue("@Id", id);

        var minionsReader = await commandGetMinionData.ExecuteReaderAsync();

        while (await minionsReader.ReadAsync())
        {
            await Console.Out.WriteLineAsync($"{minionsReader["RowNum"]}. {minionsReader["Name"]} {minionsReader["Age"]}");
        }
    }

    sqlConnection.Close();
}
