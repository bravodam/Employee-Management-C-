using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Age { get; set; }

        public List<StudentGuarantor> StudentGuarantors { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        public int? BatchId { get; set; }
        public Batch Batch { get; set; }

        public Student()
        {
        }
    }
}
