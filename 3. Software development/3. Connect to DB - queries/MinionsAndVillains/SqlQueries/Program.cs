using MySql.Data.MySqlClient;

const string connectionString = "Server=localhost;Database=MinionsDB;Uid=codeUser;Pwd=codeUserPass123";

int minMinionsCount = int.Parse(Console.ReadLine());

using (var dbConnection = new MySqlConnection(connectionString))
{
    dbConnection.Open();

    var query = @"
        SELECT Name, COUNT(*) AS MinionsCount FROM Villains AS v
        JOIN MinionsVillains AS mv
        ON mv.VillainId = v.Id
        GROUP BY v.Id
        HAVING MinionsCount > @MinMinionsCount
        ORDER BY MinionsCount DESC;";

    using (var command = new MySqlCommand(query, dbConnection))
    {
        command.Parameters.AddWithValue("MinMinionsCount", minMinionsCount);

        var villainsReader = command.ExecuteReader();

        while (villainsReader.Read())
        {
            var villainName = (string)villainsReader["Name"];
            var minionsCount = (long)villainsReader["MinionsCount"];

            Console.WriteLine($"{villainName} - {minionsCount}");
        }
    }
}