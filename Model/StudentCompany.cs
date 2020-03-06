using System;
namespace EmployeeManagement.Model
{
    public class StudentCompany
    {
        public StudentCompany()
        {
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
