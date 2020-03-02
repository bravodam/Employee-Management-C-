using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    //tokens
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private AppDbContext _db;
        public MockEmployeeRepository _emp = new MockEmployeeRepository();

        public HomeController(AppDbContext db, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _db = db;
        }

        //[Route("~/Home")]
        //[Route("~/")]
        public ViewResult Index()
        {
            var model = _emp.GetAllEmployees();
            return View(model);
        }

        public ViewResult Employees()
        {
            var model = _emp.GetAllEmployees();
            return View(model);
        }

        //[Route("{id?}")]
        public ViewResult Details(int? id)
        {

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = _emp.GetEmployee(id ?? 1);
            homeDetailsViewModel.PageTitle = "Employee Details";
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        

        

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _emp.Add(employee);
                //return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(string name, string email, Dept department)
        {
            //if (ModelState.IsValid)
            //{
                Employee e = new Employee();
                e.Department = Dept.HR;
                e.Email = "gbukhjsjk@dqefqe.rt354t35";
                e.Name = "HikhuK 4tr234";
            //return RedirectToAction("Details", new { id = newEmployee.Id });
            //}
            //return RedirectToAction("Index");
            return View(e);
        }


        

        

        public ViewResult Credential(int id)
        {
            HomeCredentialViewModel homeCredentialViewModel = new HomeCredentialViewModel();
            homeCredentialViewModel.Student = _employeeRepository.GetStudent(id);
            homeCredentialViewModel.Title = "Student List";
            return View(homeCredentialViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Students.ToListAsync() });
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            //var bookFromDb = await _db.Students.FirstOrDefaultAsync(b => b.ID == id);
            var studentToDelete = _employeeRepository.GetStudent(id);

            if (studentToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            //_db.Students.Remove(studentToDelete);
            _employeeRepository.DeleteStudent(studentToDelete);

            //await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }

        [HttpGet]
        public void Send()
        {
            
        }

    }
}
