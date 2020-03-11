using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Salary
    {
        public Salary()
        {
        }

        public int Id { get; set; }

        [Required]
        public int EmploymentId { get; set; }
        public Employment Employment { get; set; }

        [Required]
        public string Role { get; set; }

        public double Amount { get; set; }

        [Display(Name ="Company PayDay")]
        public DateTimeOffset Date { get; set; }

        [Display(Name = "Pay Back Day")]
        public DateTimeOffset PayDay { get; set; }
    }
}
