using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalary _salary;

        public SalaryController(ISalary salary)
        {
            _salary = salary;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Salary salary)
        {
            if (ModelState.IsValid)
            {
                _salary.AddSalary(salary);
                return RedirectToAction("Index");
            }
            return View(salary);
        }

        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Salary salary = _salary.GetSalaryById(id);
            if (salary != null)
            {
                return View(salary);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Salary model)
        {
            Salary salaryToUpdate = _salary.GetSalaryById(model.Id);

            if (ModelState.IsValid)
            {
                if (salaryToUpdate != null)
                {
                    salaryToUpdate.EmploymentId = model.EmploymentId;
                    salaryToUpdate.Date = model.Date;
                    salaryToUpdate.Amount = model.Amount;
                    salaryToUpdate.PayDay = model.PayDay;
                    salaryToUpdate.Role = model.Role;

                    _salary.UpdateSalary(salaryToUpdate);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var salaryDetails = _salary.GetAllSalaries().FirstOrDefault(s => s.Id == id);
            if (salaryDetails != null)
            {
                return View(salaryDetails);
            }
            return RedirectToAction("Index");
        }

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var salary = _salary.GetSalaryById(id);

            if (salary != null)
            {
                _salary.RemoveSalary(salary);
            }
            return RedirectToAction("Index");

        }

        // AJAX

        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var salaries = _salary.GetAllSalaries().ToList();
            return Json(new { data = salaries });
        }

        //DELETE
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var salaryToDelete = _salary.GetSalaryById(id);

            if (salaryToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _salary.RemoveSalary(salaryToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
