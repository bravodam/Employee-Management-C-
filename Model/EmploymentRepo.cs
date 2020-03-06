using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public IEnumerable<Employment> GetAllEmployment()
        {
            return _db.Employments.Include(e => e.Student);
        }

        public async Task<Employment> GetEmploymentByIdAsync(int id)
        {
            var employment = await _db.Employments
                .Include(e => e.Student)
                .Include(e => e.Salary)
                .FirstOrDefaultAsync(e => e.EmploymentId == id);
            return employment;
        }

        public Employment RemoveEmployment(Employment e)
        {
            throw new NotImplementedException();
        }

        public Employment UpdateEmployment(Employment e)
        {
            throw new NotImplementedException();
        }
    }
}
