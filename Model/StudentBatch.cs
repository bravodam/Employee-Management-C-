using System;
namespace EmployeeManagement.Model
{
    public class StudentBatch
    {
        public StudentBatch()
        {
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int BatchId { get; set; }
        public Batch Batch { get; set; }
    }
}
