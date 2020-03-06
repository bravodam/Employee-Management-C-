using System;
using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    public interface ISalary
    {
        Salary AddCompany(Salary s);
        Salary UpdateSalary(Salary s);
        Salary RemoveSalary(Salary s);
        Salary GetSalaryById(int id);
        IEnumerable<Salary> GetAllSalaries();
    }
}
