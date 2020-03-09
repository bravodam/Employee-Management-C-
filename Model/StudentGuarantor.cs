using System;
namespace EmployeeManagement.Model
{
    public class StudentGuarantor
    {
        public StudentGuarantor()
        {
        }

        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int GuarantorId { get; set; }
        public Guarantor Guarantor { get; set; }
    }
}
