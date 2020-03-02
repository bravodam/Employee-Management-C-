using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Model
{
    public class MockEmployeeRepository
    {
        public static List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Department = Dept.HR, Email = "a@a.com", Id = 1, Name = "Godstar"},
                new Employee() { Department = Dept.IT, Email = "b@a.com", Id = 2, Name = "Gerrald"},
                new Employee() { Department = Dept.Payroll, Email = "c@a.com", Id = 3, Name = "Ogbara"},
                new Employee() { Department = Dept.Payroll, Email = "c@a.com", Id = 3, Name = "Ogbara"},
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(em => em.Id == Id);
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
