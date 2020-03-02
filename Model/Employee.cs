using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Employee
    {
        public Employee()
        {
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }

        public override string ToString()
        {
            return this.Name + this.Id + this.Email + this.Department;
        }
    }
}
