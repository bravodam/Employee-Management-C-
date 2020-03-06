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
    public class PaymentController : Controller
    {
        private readonly IPayment _payment;

        public PaymentController(IPayment payment)
        {
            _payment = payment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            var model = new CreatePaymentViewModel();
            if (id != null)
            {
                model.StudentId = id.Value;
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _payment.AddPayment(payment);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _payment.GetPaymentById(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _payment.UpdatePayment(payment);
                return RedirectToAction("Index");
            }
            return View(payment);
        }
    }
}
