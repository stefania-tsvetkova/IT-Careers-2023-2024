using System;
using System.Collections.Generic;
using System.Text;


public class Controller
{
    private readonly Dictionary<string, Category> categories;

    public Controller()
    {
        categories = new Dictionary<string, Category>();
    }

    public string AddCategory(List<string> args)
    {
        string name = args[0];

        Category category = new Category(name);

        categories[name] = category;

        return $"Created Category {name}!";
    }

    public string AddJobOffer(List<string> args)
    {
        string categoryName = args[0];
        string jobTitle = args[1];
        string company = args[2];
        double salary = double.Parse(args[3]);
        string type = args[4];

        JobOffer offer = null;

        if (type == "onsite")
        {
            string city = args[5];
            offer = new OnSiteJobOffer(jobTitle, company, salary, city);
        }
        else
        {
            bool fullyRemot = bool.Parse(args[5]);
            offer = new RemoteJobOffer(jobTitle, company, salary, fullyRemot);
        }

        Category category = categories[categoryName];
        category.AddJobOffer(offer);

        return $"Created JobOffer {jobTitle} in Category {categoryName}!";
    }

    // TODO check when category has no offers to return 0
    public string GetAverageSalary(List<string> args)
    {
        string categoryName = args[0];

        Category category = categories[categoryName];

        double averageSalary = category.AverageSalary();

        return $"The average salary is: {averageSalary:F2} BGN";
    }

    public string GetOffersAboveSalary(List<string> args)
    {
        string categoryName = args[0];
        double salary = double.Parse(args[1]);

        Category category = categories[categoryName];
        List<JobOffer> resultOffers = category.GetOffersAboveSalary(salary);

        StringBuilder builder = new StringBuilder();

        resultOffers.ForEach(offer => builder.AppendLine(offer.ToString()));

        return builder.ToString().Trim();
    }

    public string GetOffersWithoutSalary(List<string> args)
    {
        string categoryName = args[0];

        Category category = categories[categoryName];
        List<JobOffer> resultOffers = category.GetOffersWithoutSalary();
        StringBuilder builder = new StringBuilder();

        resultOffers.ForEach(offer => builder.AppendLine(offer.ToString()));

        return builder.ToString().Trim();
    }

}