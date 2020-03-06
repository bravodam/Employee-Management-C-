using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public interface IEmployment
    {
        Employment AddEmployment(Employment e);
        Employment UpdateEmployment(Employment e);
        Employment RemoveEmployment(Employment e);
        Task<Employment> GetEmploymentByIdAsync(int id);
        IEnumerable<Employment> GetAllEmployment();
    }
}
