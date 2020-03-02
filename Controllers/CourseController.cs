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
    public class CourseController : Controller
    {
        private readonly IEmployeeRepository _empRepository;

        public CourseController(IEmployeeRepository employeeRepository, AppDbContext db)
        {
            _empRepository = employeeRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //ADD
        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _empRepository.AddCourse(course);
                return RedirectToAction("Index");
            }
            return View();
        }


        //DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            Course course = _empRepository.GetCourse(id);
            if (course != null)
            {
                ViewBag.Progs = _empRepository.GetProgrammeCourses_POnly(id);
                return View(course);
            }
            return RedirectToAction("Index");
        }

        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course course = _empRepository.GetCourse(id);
            if (course != null)
            {
                CourseEditViewModel model = new CourseEditViewModel
                {
                    Title = course.Title,
                    Code = course.Code,
                    Instructor = course.Instructor,
                    Duration = course.Duration
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CourseEditViewModel model)
        {
            Course courseToUpdate = _empRepository.GetCourse(model.CourseId);

            if (ModelState.IsValid)
            {
                if (courseToUpdate != null)
                {
                    courseToUpdate.Title = model.Title;
                    courseToUpdate.Code = model.Code;
                    courseToUpdate.Instructor = model.Instructor;
                    courseToUpdate.Duration = model.Duration;
                    courseToUpdate.Level = model.Level;

                    _empRepository.UpdateCourse(courseToUpdate);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }


        //DELETE
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var courseToDelete = _empRepository.GetCourse(id);

            if (courseToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _empRepository.DeleteCourse(courseToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var courseToDelete = _empRepository.GetCourse(id);

            if (courseToDelete != null)
            {
                _empRepository.DeleteCourse(courseToDelete);
            }
            return RedirectToAction("Index");

        }

        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _empRepository.GetAllCourses().ToList();
            return Json(new { data = courses });
        }

        //ADDSTUDENT
        [HttpGet]
        public IActionResult AddStudent(int id)
        {
            var courses = _empRepository.GetAllCourses().ToList();
            return Json(new { data = courses });
        }
    }
}
