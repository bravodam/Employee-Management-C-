using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly IEmployeeRepository _empRepository;
        private readonly AppDbContext _db;

        public CourseController(IEmployeeRepository employeeRepository, AppDbContext db)
        {
            _empRepository = employeeRepository;
            _db = db;
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
                    Level = course.Level
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

        // AJAX CALLS
        [HttpPost]
        public JsonResult SaveAjax(CourseAjaxModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Title = model.Title,
                    Level = model.Level
                };

                var newCourse = _empRepository.AddCourse(course);

                StudentCourse studentCourse = new StudentCourse
                {
                    StudentId = model.StudentId,
                    CourseId = newCourse.CourseId
                };
                var savedSG = _db.StudentCourses.Add(studentCourse);
                _db.SaveChanges();

                if (newCourse == null)
                {
                    return Json(new { success = false, message = "Error while saving" });
                }
                else
                {
                    return Json(new { success = true, message = "Object saved", type = "course", id = model.StudentId });

                }
            }
            return Json(new { success = false, message = "Invalid Submission" });
        }

        [HttpGet]
        public async Task<IActionResult> StudentCourses(int id)
        {

            var list = await _db.StudentCourses.Include(sg => sg.Course).Where(sg => sg.StudentId == id).Select(sg => sg.Course).ToListAsync();

            return Json(new { data = await _db.StudentCourses.Include(sg => sg.Course).Where(sg => sg.StudentId == id).Select(sg => sg.Course).ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> Clear(StudentCourse model)
        {
            var courseToDelete = await _db.StudentCourses.FirstOrDefaultAsync(sc => sc.StudentId == model.StudentId && sc.CourseId == model.CourseId);

            if (courseToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _db.StudentCourses.Remove(courseToDelete);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
