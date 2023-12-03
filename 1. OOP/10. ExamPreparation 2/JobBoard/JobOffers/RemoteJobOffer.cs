using System.Text;

public class RemoteJobOffer : JobOffer
{
    public RemoteJobOffer(string jobTitle, string company, double salary, bool fullyRemote)
        : base(jobTitle, company, salary)
    {
        FullyRemote = fullyRemote;
    }

    public bool FullyRemote { get; private set; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        // Traditional way of if else

        //string remoteStr = string.Empty;

        //if (FullyRemote)
        //{
        //    remoteStr = "yes";
        //}
        //else
        //{
        //    remoteStr = "no";
        //}

        // Short if else construction - ternary operator
        string fullyRemoteToStringValue = FullyRemote ? "yes" : "no";

        builder.AppendLine(base.ToString());
        builder.AppendLine($"Fully Remote: {fullyRemoteToStringValue}");

        return builder.ToString().Trim();
    }
}