namespace Machines
{
    public interface IMachine
    {
        string Type { get; }

        void Start();

        void Stop();
    }
}
