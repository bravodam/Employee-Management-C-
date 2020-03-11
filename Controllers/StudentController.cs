using System;
using System.Collections;
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
        private readonly IProject _project;
        private readonly IPayment _payment;

        public StudentController(IEmployeeRepository employeeRepo, AppDbContext db, IProject project, IPayment payment)
        {
            _employeeRepository = employeeRepo;
            _db = db;
            _project = project;
            _payment = payment;
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
                var existingBatch = _employeeRepository.GetAllBatches().Where(b => b.Id == student.BatchId).FirstOrDefault(b => b.Id == student.BatchId);

                Student studentToUpdated = _employeeRepository.GetStudent(student.StudentId);
                studentToUpdated.Name = student.Name;
                studentToUpdated.Email = student.Email;
                studentToUpdated.Gender = student.Gender;
                studentToUpdated.Age = student.Age;
                studentToUpdated.BatchId = student.BatchId;

                if (existingBatch == null)
                {
                    ModelState.AddModelError("", "Batch does not exist");
                    return View(student);
                }
            }
            return View(student);

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
                // Check if provided batch exist, if it does not return view with model error
                var existingBatch = _employeeRepository.GetAllBatches().Where(b => b.Id == student.BatchId).FirstOrDefault(b => b.Id == student.BatchId);

                if (existingBatch == null)
                {

                    ModelState.AddModelError("", "Batch does not exist");
                    return View(student);
                }

                // If batch exist, create the student, add student to joint table
                var newStudent = _employeeRepository.AddStudent(student);

                // Get cost of student's program, and use it to create a payment record
                var costOfNewStudentsProgram = _employeeRepository.GetBatch(newStudent.BatchId).Programme.Cost;

                Payment payment = new Payment
                {
                    StudentId = newStudent.StudentId,
                    Total = costOfNewStudentsProgram
                };

                _payment.AddPayment(payment);


                //StudentBatch studentBatch = new StudentBatch
                //{
                //    BatchId = newStudent.BatchId,
                //    StudentId = newStudent.StudentId
                //};

                //var result = _db.StudentBatches.Add(studentBatch);
                var result = _db.StudentBatches.Add(
                        new StudentBatch
                        {
                            BatchId = newStudent.BatchId,
                            StudentId = newStudent.StudentId
                        }
                    );

                await _db.SaveChangesAsync();

                // This line gets all the batches a student belong to from the joint table
                var batches = _db.StudentBatches
                    .Include(s => s.Batch).Where(s => s.StudentId == newStudent.StudentId).ToList();

                // If student belongs to a batch, get the program for that batch
                if (batches != null)
                {
                    var programs = new List<Programme>();
                    var list = new List<StudentCourse>();

                    foreach (var batch in batches)
                    {
                        programs.Add(_db.Programmes.Include(p => p.ProgrammeCourses).FirstOrDefault(p => p.ProgrammeId == batch.Batch.ProgrammeId));
                    }

                    // After getting all the programs of a student, get the courses a student is suppose to have offerred or to offer from the
                    // list of courses in each program
                    foreach (var program in programs)
                    {
                        foreach(var course in program.ProgrammeCourses)
                        {
                            var sc = new StudentCourse
                            {
                                CourseId = course.CourseId,
                                StudentId = newStudent.StudentId
                            };

                            list.Add(sc);
                        }
                    }

                    // Add the student course to the joint studentcourses joint table
                    foreach (var itm in list)
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
            var studentCourses = _db.StudentCourses.Include(c => c.Course).ToList();


            if (student != null)
            {

                StudentDetailsViewModel model = new StudentDetailsViewModel
                {
                    Name = student.Name,
                    Email = student.Email,
                    Gender = student.Gender,
                    Age = student.Age,
                    BatchId = student.BatchId,
                    Status = student.Status,
                    Type = student.Type,
                    StudentId = student.StudentId,
                    Payment = student.Payment,
                    StudentBatches = student.StudentBatches,
                    Projects = _project.GetStudentProjectByStudentId(student.StudentId)
                };
                var courses = studentCourses.FindAll(c => c.StudentId == id);

                var guarantors = _employeeRepository.GetAllGuarantors();
                var list = guarantors.ToList();
                ViewBag.studentGuarantors = list.FindAll(g => g.StudentId == id);
                ViewBag.courses = courses;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // DELETE

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

        // REMOVE
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


        // GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _employeeRepository.GetAllStudents();
            return Json(new { data = students });
        }
    }
}
