using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Employment
    {
        public Employment()
        {
        }

        public int EmploymentId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public Salary Salary { get; set; }

    }
}
