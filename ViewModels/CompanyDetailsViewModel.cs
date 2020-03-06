using System;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class CompanyDetailsViewModel
    {
        public CompanyDetailsViewModel()
        {
        }

        public Company Company { get; set; }

        public Student Student { get; set; }
    }
}
