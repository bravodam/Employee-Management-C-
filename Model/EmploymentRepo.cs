using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class EmploymentRepo : IEmployment
    {
        private readonly AppDbContext _db;

        public EmploymentRepo(AppDbContext db)
        {
            _db = db;
        }

        public Employment AddEmployment(Employment e)
        {
            _db.Employments.Add(e);
            _db.SaveChanges();
            return e;
        }

        public List<EmploymentIndexViewModel> GetAllEmployment()
        {
            var allEmployemts = _db.Employments.Include(e => e.Student)
                .Include(e => e.Company).Include(e => e.Salary).ToList();

            var employmentDetails = new List<EmploymentIndexViewModel>();

            foreach(var employment in allEmployemts)
            {
                EmploymentIndexViewModel employmentIndex = new EmploymentIndexViewModel
                {
                    Company = employment.Company.Name,
                    EndDate = employment.EndDate,
                    Id = employment.EmploymentId,
                    StartDate = employment.StartDate,
                    StudentName = employment.Student.Name,
                };
                if (employment.Salary != null)
                {
                    employmentIndex.Salary = employment.Salary.Amount;
                }

                employmentDetails.Add(employmentIndex);
            }

            return employmentDetails;
        }

        public Employment GetEmploymentById(int id)
        {
            var employment = _db.Employments
                .Include(e => e.Student)
                .Include(e => e.Salary)
                .Where(e => e.EmploymentId == id).FirstOrDefault(e => e.EmploymentId == id);
            return employment;
        }

        public Employment RemoveEmployment(Employment e)
        {
            _db.Employments.Remove(e);
            _db.SaveChanges();
            return e;
        }

        public Employment UpdateEmployment(Employment e)
        {
            _db.Employments.Update(e);
            _db.SaveChanges();
            return e;
        }
    }
}
