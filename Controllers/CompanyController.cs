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


        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Company company = _company.GetCompanyById(id);
            if (company != null)
            {
                return View(company);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Company model)
        {
            Company companyToUpdate = _company.GetCompanyById(model.CompanyId);

            if (ModelState.IsValid)
            {
                if (companyToUpdate != null)
                {
                    _company.UpdateCompany(model);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
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

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var company = _company.GetCompanyById(id);

            if (company != null)
            {
                _company.RemoveCompany(company);
            }
            return RedirectToAction("Index");

        }


        // AJAX

        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _company.GetAllCompanies();
            return Json(new { data = companies });
        }

        //DELETE
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var companyToDelete = _company.GetCompanyById(id);

            if (companyToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _company.RemoveCompany(companyToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
