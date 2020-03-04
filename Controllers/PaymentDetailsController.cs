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
    public class PaymentDetailsController : Controller
    {
        private readonly IPayment _payment;

        public PaymentDetailsController(IPayment payment)
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
            var model = new CreatePaymentDetailsViewModel();

            if (id != null)
            {
                model.PaymentId = id.Value;
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreatePaymentDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                PaymentDetails details = new PaymentDetails
                {
                    PaymentId = model.PaymentId,
                    AmountPaid = model.AmountPaid,
                    Date = model.Date
                };
                _payment.AddPaymentDetail(details);
                return View("Index");
            }
            return View(model);
        }
    }
}
