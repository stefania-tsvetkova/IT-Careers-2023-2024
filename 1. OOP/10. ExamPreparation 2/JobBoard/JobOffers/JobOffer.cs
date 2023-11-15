using System.Text;

public abstract class JobOffer
{
    private const int stringMinLength = 3;
    private const int stringMaxLength = 30;

    private string jobTitle;

    private string company;

    private double salary;

    protected JobOffer(string jobTitle, string company, double salary)
    {
        JobTitle = jobTitle;
        Company = company;
        Salary = salary;
    }

    public string JobTitle
    {
        get { return jobTitle; }
        private set
        {
            if (!value.IsLengthInRange(3, 30))
            {
                throw new ArgumentException(
                    string.Format(Constants.VALIDATION_LENGTH_MESSAGE, nameof(JobTitle), stringMinLength, stringMaxLength));
            }

            jobTitle = value;
        }
    }

    public string Company
    {
        get { return company; }
        private set
        {
            if (!value.IsLengthInRange(3, 30))
            {
                throw new ArgumentException(
                    string.Format(Constants.VALIDATION_LENGTH_MESSAGE, nameof(Company), stringMinLength, stringMaxLength));
            }

            company = value;
        }
    }

    public double Salary
    {
        get => salary;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.VALIDATION_SALARY_MESSAGE, nameof(Salary)));
            }

            salary = value;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Job Title: {JobTitle}");
        builder.AppendLine($"Company: {Company}");
        builder.AppendLine($"Salary: {Salary:F2} BGN");

        return builder.ToString().Trim();
    }
}