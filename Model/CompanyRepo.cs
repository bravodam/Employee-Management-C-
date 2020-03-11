using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class CompanyRepo : ICompany
    {
        private readonly AppDbContext _db;

        public CompanyRepo(AppDbContext db)
        {
            _db = db;
        }

        public Company AddCompany(Company c)
        {
            _db.Companies.Add(c);
            _db.SaveChanges();
            return c;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _db.Companies;
        }

        public Company GetCompanyById(int id)
        {
            var company = _db.Companies
                .Include(c => c.Employments)
                .FirstOrDefault(c => c.CompanyId == id);
            return company;
        }

        public Company RemoveCompany(Company c)
        {
            _db.Companies.Remove(c);
            _db.SaveChanges();
            return c;
        }

        public Company UpdateCompany(Company c)
        {
            var company = _db.Companies.FirstOrDefault(com => com.CompanyId == c.CompanyId);

            company.Address = c.Address;
            company.ContactEmail = c.ContactEmail;
            company.ContactName = c.ContactName;
            company.Name = c.Name;

            _db.Companies.Update(company);
            _db.SaveChanges();
            return c;
        }
    }
}
