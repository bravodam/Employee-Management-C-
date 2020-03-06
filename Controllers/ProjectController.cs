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
    public class ProjectController : Controller
    {
        private readonly IProject _project;

        public ProjectController(IProject project)
        {
            _project = project;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

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
        public IActionResult Create(Project model)
        {
            if (ModelState.IsValid)
            {
                Project project = new Project
                {
                    Title = model.Title,
                    StudentId = model.StudentId,
                    Description = model.Description,
                    GitUrl = model.GitUrl
                };
                var savedProject = _project.AddProject(project);

                if (savedProject != null)
                {
                    StudentProject studentProject = new StudentProject
                    {
                        StudentId = savedProject.StudentId,
                        ProjectId = savedProject.ProjectId
                    };

                        _project.AddStudentProject(studentProject);

                    return RedirectToAction("Index");
                }
                
            }
            return View(model);
        }
    }
}
