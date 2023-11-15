using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        bool isInRange = "Gosho".IsLengthInRange(3, 5);

        Controller controller = new Controller();
        bool isRunning = true;

        StringBuilder stringBuilder = new StringBuilder();

        while (isRunning)
        {
            string[] splittedInput = Console.ReadLine().Split();

            string command = splittedInput[0];
            List<string> arguments = splittedInput
                .Skip(1)
                .ToList();

            

            string result = "";
            try
            {
                switch (command)
                {
                    case "AddCategory":
                        result = controller.AddCategory(arguments);
                        break;
                    case "AddJobOffer":
                        result = controller.AddJobOffer(arguments);
                        break;
                    case "GetAverageSalary":
                        result = controller.GetAverageSalary(arguments);
                        break;
                    case "GetOffersAboveSalary":
                        result = controller.GetOffersAboveSalary(arguments);
                        break;
                    case "GetOffersWithoutSalary":
                        result = controller.GetOffersWithoutSalary(arguments);
                        break;
                    case "End":
                        isRunning = false;
                        break;
                    default:
                        result = "Invalid command";
                        break;
                }

                if (!isRunning) { break; }
                stringBuilder.AppendLine(result);
            }
            catch (Exception e)
            {
                stringBuilder.AppendLine(e.Message);
            }
        }

        Console.WriteLine(stringBuilder.ToString().Trim());
    }
}