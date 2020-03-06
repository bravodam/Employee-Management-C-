using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _company.AddCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            var company = _company.GetCompanyById(id);

            if (company != null)
            {
                return View(company);
            }
            return RedirectToAction("Index");
        }


        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _company.GetAllCompanies();
            return Json(new { data = companies });
        }
    }
}
