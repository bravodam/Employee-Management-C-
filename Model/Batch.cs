using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Model
{
    public class Batch
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Supervisor { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ProgrammeId { get; set; }
        public Programme Programme { get; set; }


        //public List<Student> StudentsInBatch { get; set; }
        public List<StudentBatch> StudentBatches { get; set; }
    }
}
