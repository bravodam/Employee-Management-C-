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

        // CREATE
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

        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employment employment = _employment.GetEmploymentById(id);
            if (employment != null)
            {
                return View(employment);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Employment model)
        {
            Employment employmentToUpdate = _employment.GetEmploymentById(model.EmploymentId);

            if (ModelState.IsValid)
            {
                if (employmentToUpdate != null)
                {
                    employmentToUpdate.CompanyId = model.CompanyId;
                    employmentToUpdate.EndDate = model.EndDate;
                    employmentToUpdate.StartDate = model.StartDate;
                    employmentToUpdate.StudentId = model.StudentId;
                    _employment.UpdateEmployment(employmentToUpdate);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var listOfEmployments = _employment.GetAllEmployment();

            var model = listOfEmployments.Find(e => e.Id == id);

            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }


        // AJAX

        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var employments = _employment.GetAllEmployment();
            return Json(new { data = employments.ToList() });
        }

        //DELETE
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var employmentToDelete = _employment.GetEmploymentById(id);

            if (employmentToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }

            _employment.RemoveEmployment(employmentToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
