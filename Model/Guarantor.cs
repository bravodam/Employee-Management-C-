using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Guarantor
    {
        public Guarantor()
        {
        }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string DocUrl { get; set; }

        public List<StudentGuarantor> StudentGuarantors { get; set; }
    }
}
