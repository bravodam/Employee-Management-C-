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
    public class StudentController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDbContext _db;

        public StudentController(IEmployeeRepository employeeRepo, AppDbContext db)
        {
            _employeeRepository = employeeRepo;
            _db = db;
        }
        //INDEX
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Student> model = _employeeRepository.GetAllStudents();
            return View(model);
        }

        //EDIT
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _employeeRepository.GetStudent(id);
            EditStudentViewModel model = new EditStudentViewModel
            {
                Name = student.Name,
                Email = student.Email,
                Gender = student.Gender,
                Age = student.Age,
                StudentId = student.StudentId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditStudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                Student studentToUpdated = _employeeRepository.GetStudent(student.StudentId);
                studentToUpdated.Name = student.Name;
                studentToUpdated.Email = student.Email;
                studentToUpdated.Gender = student.Gender;
                studentToUpdated.Age = student.Age;
                _employeeRepository.UpdateStudent(studentToUpdated);
            }
            return RedirectToAction("Index");

        }

        //REGISTER
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Student student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = _employeeRepository.AddStudent(student);

                Batch studentBatch = _db.Students
                    .Include(s => s.Batch).FirstOrDefault(s => s.StudentId == newStudent.StudentId).Batch;

                var studentBatchProgram = _db.ProgrammeCourses
                    .Include(pc => pc.Course).Where(pc => pc.ProgrammeId == studentBatch.ProgrammeId);

                

                if (studentBatchProgram != null)
                {
                    var list = new List<StudentCourse>();
                    foreach (var p in studentBatchProgram)
                    {
                        var sc = new StudentCourse
                        {
                            CourseId = p.CourseId,
                            StudentId = newStudent.StudentId
                        };

                        list.Add(sc);
                    }
                    
                    foreach(var itm in list)
                    {
                        _db.StudentCourses.Add(itm);
                        await _db.SaveChangesAsync();
                    }
                }

                return RedirectToAction("Index");
            }

            return View();
        }
        
        //ADDCOURSE
        [HttpGet]
        public IActionResult AddCourse(int id)
        {
            ViewBag.studentId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(AddCourseViewModel model, int id)
        {
            var courses = _employeeRepository.GetAllCourses().ToList();

            var course = courses.FirstOrDefault(c => c.Title == model.Title);
            StudentCourse studentCourse = new StudentCourse
            {
                CourseId = course.CourseId,
                StudentId = id
            };

            _db.StudentCourses.Add(studentCourse);
            _db.SaveChanges();
            return RedirectToAction("Details", new { Id = id });
        }

        /*
         *TODO
         *Use try catch on AddCourse action method
         */

        //DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            Student student = _employeeRepository.GetStudent(id);
            var studentCourses = _db.StudentCourses.ToList();


            if (student != null)
            {
                var courses = studentCourses.FindAll(c => c.StudentId == id);

                var guarantors = _employeeRepository.GetAllGuarantors();
                var list = guarantors.ToList();
                ViewBag.studentGuarantors = list.FindAll(g => g.StudentId == id);
                ViewBag.courses = courses;
                return View(student);
            }
            return RedirectToAction("Index");
        }

        //DELETE

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var studentToDelete = _employeeRepository.GetStudent(id);

            if (studentToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _employeeRepository.DeleteStudent(studentToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var studentToDelete = _employeeRepository.GetStudent(id);

            if (studentToDelete != null)
            {
                _employeeRepository.DeleteStudent(studentToDelete);
            }
            return RedirectToAction("Index");
        }


        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _employeeRepository.GetAllStudents();
            return Json(new { data = students });
        }
    }
}
