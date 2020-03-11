using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class SalaryRepo : ISalary
    {
        private readonly AppDbContext _db;

        public SalaryRepo(AppDbContext db)
        {
            _db = db;
        }

        public Salary AddSalary(Salary s)
        {
            _db.Salaries.Add(s);
            _db.SaveChanges();
            return s;
        }

        public List<SalaryDetailsViewModel> GetAllSalaries()
        {
            var allSalaries = _db.Salaries.Include(s => s.Employment)
                .Include(s => s.Employment.Company)
                .Include(s => s.Employment.Student).ToList();

            var details = new List<SalaryDetailsViewModel>();

            foreach(var salary in allSalaries)
            {
                SalaryDetailsViewModel salaryDetailsView = new SalaryDetailsViewModel
                {
                    Amount = salary.Amount,
                    CompanyName = salary.Employment.Company.Name,
                    Date = salary.Date,
                    EmploymentId = salary.EmploymentId,
                    Id = salary.Id,
                    PayDay = salary.PayDay,
                    Role = salary.Role,
                    StudentName = salary.Employment.Student.Name
                };
                details.Add(salaryDetailsView);
            }
            return details;
        }

        public Salary GetSalaryById(int id)
        {
            return _db.Salaries.Include(s => s.Employment).FirstOrDefault(s => s.Id == id);
        }

        public Salary RemoveSalary(Salary s)
        {
            _db.Salaries.Remove(s);
            _db.SaveChanges();
            return s;
        }

        public Salary UpdateSalary(Salary s)
        {
            _db.Salaries.Update(s);
            _db.SaveChanges();
            return s;
        }
    }
}
