using System;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class SalaryDetailsViewModel : Salary
    {
        public SalaryDetailsViewModel()
        {
        }

        public string StudentName { get; set; }

        public string CompanyName { get; set; }
    }
}
