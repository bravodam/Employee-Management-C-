using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Programme
    {
        public int ProgrammeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }

        public double Cost { get; set; }

        public List<ProgrammeCourse> ProgrammeCourses { get; set; }

        public List<Batch> Batches { get; set; }
    }
}
