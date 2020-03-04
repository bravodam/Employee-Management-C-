using System;
namespace EmployeeManagement.Model
{
    public class Salary
    {
        public Salary()
        {
        }

        public int Id { get; set; }

        public int EmploymentId { get; set; }

        public string Role { get; set; }

        public double Amount { get; set; }

        public DateTimeOffset Date { get; set; }

        public DateTimeOffset PayDay { get; set; }
    }
}
