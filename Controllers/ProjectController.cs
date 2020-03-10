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
    public class ProjectController : Controller
    {
        private readonly IProject _project;
        private readonly AppDbContext _db;

        public ProjectController(IProject project, AppDbContext db)
        {
            _project = project;
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        // CREATE
        [HttpGet]
        public IActionResult Create(int? id)
        {
            CreateProjectViewModel model = new CreateProjectViewModel();

            if (id != null)
            {
                model.StudentId = id.Value;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project
                {
                    Title = model.Title,
                    Description = model.Description,
                    GitUrl = model.GitUrl
                };
                var savedProject = _project.AddProject(project);

                if (savedProject != null)
                {
                    StudentProject studentProject = new StudentProject
                    {
                        StudentId = model.StudentId,
                        ProjectId = savedProject.ProjectId
                    };

                        _project.AddStudentProject(studentProject);

                    return RedirectToAction("Index");
                }
                
            }
            return View(model);
        }

        // DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            var project = _project.GetProjectById(id);

            if (project != null)
            {
                return View(project);
            }
            return RedirectToAction("Index");
        }


        // AJAX CALLS
        [HttpPost]
        public JsonResult SaveAjax(ProjectAjaxViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project
                {
                    Title = model.Title,
                    Description = model.Description,
                    GitUrl = model.GitUrl
                };

                var newProject = _project.AddProject(project);

                StudentProject studentProject = new StudentProject
                {
                    StudentId = model.StudentId,
                    ProjectId = newProject.ProjectId
                };
                var savedSP = _db.StudentProjects.Add(studentProject);
                _db.SaveChanges();

                if (savedSP == null)
                {
                    return Json(new { success = false, message = "Error while saving" });
                }
                else
                {
                    return Json(new { success = true, message = "Object saved", type = "project", id = model.StudentId });

                }
            }
            return Json(new { success = false, message = "Invalid Submission" });
        }

        [HttpGet]
        public async Task<IActionResult> StudentProjects(int id)
        {
            return Json(new { data = await _db.StudentProjects.Include(sp => sp.Project).Where(sp => sp.StudentId == id).Select(Span => Span.Project).ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Clear(StudentProject model)
        {
            var projectToDelete = await _db.StudentProjects.FirstOrDefaultAsync(sc => sc.StudentId == model.StudentId && sc.ProjectId == model.ProjectId);

            if (projectToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _db.StudentProjects.Remove(projectToDelete);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
