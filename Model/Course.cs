using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Course
    {
        public Course()
        {
        }
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }

        public string Code { get; set; }
        [Required]
        public string Instructor { get; set; }

        public CourseLevel Level { get; set; }

        public string Duration { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        public List<ProgrammeCourse> ProgrammeCourses { get; set; }

    }
}
