using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeManagement.Model
{
    public class ProgrammeCourse
    {

        public int ProgrammeId { get; set; }
        public Programme Programme { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
