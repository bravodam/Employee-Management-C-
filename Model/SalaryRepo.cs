using System;
using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    public class SalaryRepo : ISalary
    {
        private readonly AppDbContext _db;

        public SalaryRepo(AppDbContext db)
        {
            _db = db;
        }

        public Salary AddCompany(Salary s)
        {
            _db.Salaries.Add(s);
            _db.SaveChanges();
            return s;
        }

        public IEnumerable<Salary> GetAllSalaries()
        {
            throw new NotImplementedException();
        }

        public Salary GetSalaryById(int id)
        {
            throw new NotImplementedException();
        }

        public Salary RemoveSalary(Salary s)
        {
            throw new NotImplementedException();
        }

        public Salary UpdateSalary(Salary s)
        {
            throw new NotImplementedException();
        }
    }
}
