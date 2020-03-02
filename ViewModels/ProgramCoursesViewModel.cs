using System;
namespace EmployeeManagement.ViewModels
{
    public class ProgramCoursesViewModel
    {
        public ProgramCoursesViewModel()
        {
        }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public bool IsSelected { get; set; }
    }
}
