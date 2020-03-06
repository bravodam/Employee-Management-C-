using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class EmploymentController : Controller
    {
        private readonly IEmployment _employment;

        public EmploymentController(IEmployment employment)
        {
            _employment = employment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int? companyId, int? studentId)
        {
            CreateEmploymentViewModel model = new CreateEmploymentViewModel();

            if (companyId != null && studentId == null)
            {
                model.CompanyId = companyId.Value;
                return View(model);
            }
            else if (companyId == null && studentId != null)
            {
                model.StudentId = studentId.Value;
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateEmploymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _employment.AddEmployment(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
