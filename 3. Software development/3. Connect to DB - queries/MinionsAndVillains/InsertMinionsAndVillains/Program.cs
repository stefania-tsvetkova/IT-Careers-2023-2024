using InsertMinionsAndVillains;
using MySql.Data.MySqlClient;
using SqlQueries;

const string connectionString = "Server=localhost;Database=MinionsDB;Uid=codeUser;Pwd=codeUserPass123";

var minionInput = InputHelper.GetInputData()
    .Split(' ')
    .ToArray();

var minionName = minionInput[0];
var minionAge = minionInput[1];
var minionTown = minionInput[2];

var villainName = InputHelper.GetInputData();

using (var dbConnection = new MySqlConnection(connectionString))
{
    dbConnection.Open();

    var minionId = DbHelper.GetMinionId(dbConnection, minionName, minionAge, minionTown);
    if (minionId is null)
    {
        var isMinionAdded = DbHelper.AddMinion(dbConnection, minionName, minionAge, minionTown);
        if (!isMinionAdded)
        {
            throw new Exception("Error adding minion");
        }

        Console.WriteLine($"Successfully added minion {minionName}");

        minionId = DbHelper.GetMinionId(dbConnection, minionName, minionAge, minionTown);
    }

    // ToDo: add villain

    // ToDo: add minion to the villain
}