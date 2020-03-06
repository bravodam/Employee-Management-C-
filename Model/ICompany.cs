using System;
using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    public interface ICompany
    {
        Company AddCompany(Company c);
        Company UpdateCompany(Company c);
        Company RemoveCompany(Company c);
        Company GetCompanyById(int id);
        IEnumerable<Company> GetAllCompanies();
    }
}
