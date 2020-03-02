using System;
using System.Collections.Generic;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class ProgrammeDetailsViewModel : Programme
    {
        public ProgrammeDetailsViewModel()
        {
        }

        public List<ProgrammeCourse> Prog_Courses { get; set; }

    }
}

