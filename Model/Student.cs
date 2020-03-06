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

        [Required]
        public int BatchId { get; set; }

        public List<StudentGuarantor> StudentGuarantors { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        

        public List<StudentBatch> StudentBatches { get; set; }

        public Status Status { get; set; }

        public Payment Payment { get; set; }

        public StudentType Type { get; set; }


        public List<StudentCompany> StudentCompanies { get; set; }

        public List<StudentProject> StudentProjects { get; set; }


        public Student()
        {
        }
    }
}
