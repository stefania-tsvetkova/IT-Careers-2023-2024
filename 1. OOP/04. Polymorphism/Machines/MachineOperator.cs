namespace Machines
{
    public class MachineOperator
    {
        public void StartMachine(IMachine machine)
            => machine.Start();

        public void StopMachine(IMachine machine)
            => machine.Stop();
    }
}
