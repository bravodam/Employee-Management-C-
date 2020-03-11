using System;
namespace EmployeeManagement.ViewModels
{
    public class EmploymentIndexViewModel
    {
        public EmploymentIndexViewModel()
        {
        }

        public int Id { get; set; }

        public string StudentName { get; set; }

        public string Company { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public double Salary { get; set; }
    }
}
