namespace Employees
{
    public class ContractEmployee : BaseEmployee
    {
        private string employeeTask;

        private string employeeDepartment;

        public ContractEmployee(
            string employeeId,
            string employeeName,
            string employeeAddress,
            string employeeTask,
            string employeeDepartment)
            : base(employeeId, employeeName, employeeAddress)
        {
            this.employeeTask = employeeTask;
            this.employeeDepartment = employeeDepartment;
        }

        public override void Show()
        {
            base.Show();

            Console.WriteLine($"Task: {employeeTask}");
            Console.WriteLine($"Department: {employeeDepartment}");
        }

        public override double CalculateSalary(int workingHours)
            => 250 + workingHours * 20;

        public override string GetDepartment()
            => employeeDepartment;
    }
}
