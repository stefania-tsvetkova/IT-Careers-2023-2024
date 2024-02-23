using MySql.Data.MySqlClient;
using SqlQueries;

namespace InsertMinionsAndVillains
{
    public static class DbHelper
    {
        public static int? GetMinionId(MySqlConnection dbConnection, string name, string age, string town)
        {
            using (var command = new MySqlCommand(Queries.GetMinionId, dbConnection))
            {
                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Age", age);
                command.Parameters.AddWithValue("Town", town);

                var minionId = (int?)command.ExecuteScalar();

                return minionId;
            }
        }

        public static bool AddMinion(MySqlConnection dbConnection, string name, string age, string town)
        {
            var townId = GetTownId(dbConnection, town);
            if (townId is null)
            {
                var isTownAdded = AddTown(dbConnection, town);
                if (!isTownAdded)
                {
                    throw new Exception("Error adding town");
                }

                Console.WriteLine($"Successfully added town {town}");

                townId = GetTownId(dbConnection, town);
            }

            using (var command = new MySqlCommand(Queries.InsertMinion, dbConnection))
            {
                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Age", age);
                command.Parameters.AddWithValue("TownId", townId);

                return command.ExecuteNonQuery() > 0;
            }
        }

        private static int? GetTownId(MySqlConnection dbConnection, string name)
        {
            using (var command = new MySqlCommand(Queries.GetTownId, dbConnection))
            {
                command.Parameters.AddWithValue("Name", name);

                var townId = (int?)command.ExecuteScalar();

                return townId;
            }
        }

        private static bool AddTown(MySqlConnection dbConnection, string name)
        {
            using (var command = new MySqlCommand(Queries.InsertTown, dbConnection))
            {
                command.Parameters.AddWithValue("Name", name);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
