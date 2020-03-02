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
    public class BatchController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDbContext _db;

        public BatchController(IEmployeeRepository employeeRepository, AppDbContext db)
        {
            _employeeRepository = employeeRepository;
            _db = db;
        }

        // GET: /<controller>/ INDEX
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
        public IActionResult Create(Batch batch)
        {
            
            if (ModelState.IsValid)
            {
                _employeeRepository.AddBatch(batch);
                return RedirectToAction("Index");
            }
            return View();
        }

        //DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            var batch = _employeeRepository.GetBatch(id);

            if (batch != null)
            {
                BatchDetailsViewModel model = new BatchDetailsViewModel
                {
                    Name = batch.Name,
                    Supervisor = batch.Supervisor,
                    StartDate = batch.StartDate,
                    EndDate = batch.EndDate,
                    Id = batch.Id,
                    Prog = batch.Programme
                };
                return View(model);
            }
            return View();
        }

        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var batch = _employeeRepository.GetBatch(id);
            if (batch != null)
            {
                
                return View(batch);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Batch model)
        {
            var batch = _employeeRepository.GetBatch(model.Id);
            if (batch != null)
            {
                batch.Name = model.Name;
                batch.Supervisor = model.Supervisor;
                batch.StartDate = model.StartDate;
                batch.EndDate = model.EndDate;
                _employeeRepository.UpdateBatch(batch);
                return RedirectToAction("Index");
            }
            return View();
        }

        //GETALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var batches = _db.Batches;
            return Json(new { data = batches });
        }

        //DELETE
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var batchToDelete = _employeeRepository.GetBatch(id);

            if (batchToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _employeeRepository.DeleteBatch(batchToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var batchToDelete = _employeeRepository.GetBatch(id);

            if (batchToDelete != null)
            {
                _employeeRepository.DeleteBatch(batchToDelete);
            }
            return RedirectToAction("Index");
        }
    }
}
