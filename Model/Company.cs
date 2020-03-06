using System;
using System.Collections.Generic;
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
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        [Required]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }

        public List<Employment> Employments { get; set; }

        public List<StudentCompany> StudentCompanies { get; set; }

    }
}
