using System;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class CreateProjectViewModel : Project
    {
        public CreateProjectViewModel()
        {
        }

        public int StudentId { get; set; }
    }
}
