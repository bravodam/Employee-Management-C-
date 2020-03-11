using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Model
{
    public interface IEmployment
    {
        Employment AddEmployment(Employment e);
        Employment UpdateEmployment(Employment e);
        Employment RemoveEmployment(Employment e);
        Employment GetEmploymentById(int id);
        List<EmploymentIndexViewModel> GetAllEmployment();
    }
}
