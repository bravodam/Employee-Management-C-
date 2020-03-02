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
    public class ProgrammeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDbContext _db;

        public ProgrammeController(IEmployeeRepository employeeRepository, AppDbContext db)
        {
            _employeeRepository = employeeRepository;
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Programme programme)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.AddProgramme(programme);
                return RedirectToAction("Index");
            }
            return View();
        }

        //DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            var prog_course = _employeeRepository.GetProgrammeCourses(id);


            var PC = _db.ProgrammeCourses.Where(pc => pc.ProgrammeId == id).ToList();
            ViewBag.PC = PC;
            var programme = _employeeRepository.GetProgramme(id);
            ProgrammeDetailsViewModel model = new ProgrammeDetailsViewModel
            {
                Name = programme.Name,
                Cost = programme.Cost,
                Duration = programme.Duration,
                ProgrammeId = programme.ProgrammeId,
                Prog_Courses = _employeeRepository.GetProgrammeCourses(id)
            };
            return View(model);
        }

        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var programme = _employeeRepository.GetProgramme(id);
            if (programme != null)
            {

                return View(programme);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Programme model)
        {
            if (ModelState.IsValid)
            {
                var programme = _employeeRepository.GetProgramme(model.ProgrammeId);
                if (programme != null)
                {
                    programme.Name = model.Name;
                    programme.Cost = model.Cost;
                    programme.Duration = model.Duration;

                    _employeeRepository.UpdateProgramme(programme);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var programmes = _employeeRepository.GetAllProgrammes();
            return Json(new { data = programmes });
        }

        //DELETE
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var programmeToDelete = _employeeRepository.GetProgramme(id);

            if (programmeToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _employeeRepository.DeleteProgramme(programmeToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var programmeToDelete = _employeeRepository.GetProgramme(id);

            if (programmeToDelete != null)
            {
                _employeeRepository.DeleteProgramme(programmeToDelete);
            }
            return RedirectToAction("Index");
        }

        //MANAGE DATA

        //MANAGE PROGRAMME COURSE
        [HttpGet]
        public IActionResult ManageProgrammeCourses(int id)
        {
            ViewBag.progId = id;

            var prog = _employeeRepository.GetProgramme(id);

            var allCourses = _employeeRepository.GetAllCourses();

            var programmeCourses = new List<Course>();

            var coursesCount = _employeeRepository.GetProgrammeCourses(id);

            if (prog != null)
            {
                var model = new List<ProgramCoursesViewModel>();
                foreach(var course in coursesCount)
                {
                    
                    programmeCourses.Add(_employeeRepository.GetCourse(course.CourseId));
                }

                foreach (var c in allCourses)
                {
                    var progCourse = new ProgramCoursesViewModel
                    {
                        CourseId = c.CourseId,
                        CourseTitle = _employeeRepository.GetCourse(c.CourseId).Title,
                    };
                    if (programmeCourses.Contains(c))
                    {
                        progCourse.IsSelected = true;
                    }
                    else
                    {
                        progCourse.IsSelected = false;
                    }
                    model.Add(progCourse);
                }
                return View(model);
            }
            return RedirectToAction("Details");
        }

        [HttpPost]
        public async Task<IActionResult> ManageProgrammeCourses(List<ProgramCoursesViewModel> model, int id)
        {
            var data = new ProgrammeCourse();
            foreach(var item in model)
            {
                var included = false;
                //var courses = _employeeRepository.GetProgrammeCourses(id);
                var courses = _db.ProgrammeCourses.Where(c => c.ProgrammeId == id);



                if (item.IsSelected)
                {
                    if (courses.Count() > 0)
                    {
                        foreach (var course in courses)
                        {
                            if (course.CourseId == item.CourseId && course.ProgrammeId == id)
                            {
                                included = true;
                            }
                        }

                        if (!included)
                        {
                            data = new ProgrammeCourse
                            {
                                CourseId = item.CourseId,
                                ProgrammeId = id
                            };
                            _db.ProgrammeCourses.Add(data);
                            await _db.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        data = new ProgrammeCourse
                        {
                            CourseId = item.CourseId,
                            ProgrammeId = id
                        };
                        _db.ProgrammeCourses.Add(data);
                        await _db.SaveChangesAsync();
                    }

                }
                else
                {
                    if (courses.Count() > 0)
                    {
                        foreach (var course in courses)
                        {
                            if (course.CourseId == item.CourseId && course.ProgrammeId == id)
                            {
                                included = true;
                            }
                        }

                        if (included)
                        {
                            data = new ProgrammeCourse
                            {
                                CourseId = item.CourseId,
                                ProgrammeId = id
                            };
                            //_db.ProgrammeCourses.Where(pc => pc.ProgrammeId == id && pc.CourseId == data.CourseId);
                            var l = _db.ProgrammeCourses.ToList();
                            for (int i = 0; i < l.Count; i++)
                            {
                               if (l[i].ProgrammeId == id && l[i].CourseId == item.CourseId)
                                {
                                    _db.Remove(l[i]);
                                    _db.SaveChanges();
                                }
                            }
                            await _db.SaveChangesAsync();
                        }
                    }
                }
            }
            return RedirectToAction("Details", new { id = id });
        }


    }
}
