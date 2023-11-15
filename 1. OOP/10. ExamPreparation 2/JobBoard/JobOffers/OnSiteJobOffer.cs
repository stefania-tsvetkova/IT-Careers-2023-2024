using System.Text;

public class OnSiteJobOffer : JobOffer
{
    private string city;

    public OnSiteJobOffer(string jobTitle, string company, double salary, string city)
        :base(jobTitle, company, salary)
    {
        City = city;
    }

    public string City
    {
        get => city;
        private set 
        {
            if (!value.IsLengthInRange(3, 30))
            {
                throw new ArgumentException($"{nameof(City)} should be between 3 and 30 characters!");
            }

            city = value;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(base.ToString());
        builder.AppendLine($"City: {City}");

        return builder.ToString().Trim();
    }
}