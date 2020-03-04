using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Company
    {
        public Company()
        {
        }

        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactEmail { get; set; }
    }
}
