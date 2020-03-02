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
    public class GuarantorController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDbContext _db;

        public GuarantorController(IEmployeeRepository employeeRepository, AppDbContext db)
        {
            _employeeRepository = employeeRepository;
            _db = db;
        }

        //INDEX
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _employeeRepository.GetAllGuarantors();
            return View(model);
        }

        //EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _employeeRepository.GetGuarantor(id);
            GuarantorEditViewModel guarantorEditViewModel = new GuarantorEditViewModel
            {
                DocUrl = model.DocUrl,
                Name = model.Name,
                StudentId = model.StudentId,
                Phone = model.Phone,
                ID = model.ID
            };
            return View(guarantorEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(GuarantorEditViewModel guarantorEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Guarantor guarantor = _employeeRepository.GetGuarantor(guarantorEditViewModel.ID);
                guarantor.DocUrl = guarantorEditViewModel.DocUrl;
                guarantor.StudentId = guarantorEditViewModel.StudentId;
                guarantor.Phone = guarantorEditViewModel.Phone;
                guarantor.Name = guarantorEditViewModel.Name;

                _employeeRepository.UpdateGuarantor(guarantor);
                return RedirectToAction("Index");
            }
            return View();
        }

        //DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            Guarantor guarantor = _employeeRepository.GetGuarantor(id);
            if (guarantor != null)
            {
                ViewBag.Developer = _employeeRepository.GetStudent(guarantor.StudentId);

                var sg = _db.StudentGuarantor
                    .Include(sg => sg.Student)
                    .Where(sg => sg.GuarantorId == id);

                ViewBag.guarantorFor = sg;

                return View(guarantor);
            }
            return RedirectToAction("Index");
        }

        
        //ADD
        [HttpGet]
        public IActionResult AddGuarantor(int? studentId)
        {
            AddGuarantorViewModel model = new AddGuarantorViewModel();
            if (studentId != null)
            {
                model.StudentId = studentId.Value;
                ViewBag.sId = studentId;
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AddGuarantor(AddGuarantorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guarantor guarantor = new Guarantor();
                guarantor.Name = model.Name;
                guarantor.StudentId = model.StudentId;
                guarantor.Phone = model.Phone;
                guarantor.DocUrl = model.DocUrl;
                var newGuarantor = _employeeRepository.AddGuarantor(guarantor);

                StudentGuarantor studentGuarantor = new StudentGuarantor
                {
                    GuarantorId = newGuarantor.ID,
                    StudentId = model.StudentId
                };
                _db.StudentGuarantor.Add(studentGuarantor);
                _db.SaveChanges();

                return RedirectToAction("Index", "Guarantor");
            }
            return View(model);
        }

        //DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var guarantorToDelete = await _db.Guarantors.FirstOrDefaultAsync(b => b.ID == id);

            if (guarantorToDelete == null)
            {
                return Json(new { success = false, message = "Error while deletiing" });
            }
            _employeeRepository.DeleteGuarantor(guarantorToDelete);

            return Json(new { success = true, message = "Delete Successful" });
        }

        //REMOVE
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var guarantorToDelete = _employeeRepository.GetGuarantor(id);

            if (guarantorToDelete != null)
            {
                _employeeRepository.DeleteGuarantor(guarantorToDelete);
            }
            return RedirectToAction("Index");

        }

        //GETALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Guarantors.ToListAsync() });
        }
    }
}
