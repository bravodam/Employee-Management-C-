using System;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }

        public HomeDetailsViewModel()
        {
        }

        public override string ToString()
        {
            return this.Employee.ToString() + this.PageTitle;
        }
    }
}
