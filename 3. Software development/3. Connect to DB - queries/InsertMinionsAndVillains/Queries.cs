namespace SqlQueries
{
    public static class Queries
    {
        public static readonly string GetMinionId = @"
            SELECT m.Id FROM Minions AS m
            JOIN Towns AS t
            ON m.TownId = t.Id
            WHERE m.Name = @Name AND m.Age = @Age AND t.Name = @Town
            LIMIT 1;";

        public static readonly string GetTownId = @"
            SELECT Id FROM Towns
            WHERE Name = @Name";

        public static readonly string InsertTown = @"
            INSERT INTO Towns(Name)
            VALUES (@Name)";

        public static readonly string InsertMinion = @"
            INSERT INTO Minions(Name, Age, TownId)
            VALUES (@Name, @Age, @TownId)";
    }
}
