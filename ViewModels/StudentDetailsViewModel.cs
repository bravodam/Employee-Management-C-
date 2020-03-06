using System;
using System.Collections.Generic;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class StudentDetailsViewModel : Student
    {
        public StudentDetailsViewModel()
        {
        }


        public List<StudentProject> Projects { get; set; }
    }
}
