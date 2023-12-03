using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

public class Category
{
    private string name;
    private List<JobOffer> offers;

    public Category(string name)
    {
        Name = name;
        offers = new List<JobOffer>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (!value.IsLengthInRange(2, 40))
            {
                throw new ArgumentException($"{nameof(Name)} should be between 2 and 40 characters!");
            }

            name = value;
        }
    }

    public void AddJobOffer(JobOffer offer)
    {
        offers.Add(offer);
    }

    public double AverageSalary()
    {
        if (offers.Count == 0)
        {
            return 0;
        }

        return offers
            .Average(offer => offer.Salary);
    }

    public List<JobOffer> GetOffersAboveSalary(double salary)
    {
        return offers
            .Where(offer => offer.Salary >= salary)
            .OrderByDescending(offer => offer.Salary)
            .ToList();
    }

    public List<JobOffer> GetOffersWithoutSalary()
    {
        return offers
            .Where(offer => offer.Salary == 0)
            .OrderBy(offer => offer.Company)
            .ToList();
    }

    public override string ToString()
    {
        //StringBuilder builder = new StringBuilder();

        //builder.AppendLine($"Category {Name}");
        //builder.AppendLine($"Total Offers: {offers.Count}");

        //return builder.ToString().Trim();

        return $"Category {Name}" +
            $"{Environment.NewLine}" +
            $"Total Offers: {offers.Count}";
    }
}