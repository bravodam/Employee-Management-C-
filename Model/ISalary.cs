using System;
using System.Collections.Generic;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Model
{
    public interface ISalary
    {
        Salary AddSalary(Salary s);
        Salary UpdateSalary(Salary s);
        Salary RemoveSalary(Salary s);
        Salary GetSalaryById(int id);
        List<SalaryDetailsViewModel> GetAllSalaries();
    }
}
