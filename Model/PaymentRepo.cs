using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class PaymentRepo : IPayment
    {
        private readonly AppDbContext _db;

        public PaymentRepo(AppDbContext db)
        {
            _db = db;
        }

        public Payment AddPayment(Payment payment)
        {
            _db.Payments.Add(payment);
            _db.SaveChanges();
            return payment;
        }

        public List<PaymentIndexView> GetAllPayment()
        {
            PaymentIndexView pv = new PaymentIndexView();
            var payments = new List<PaymentIndexView>();
            var list = _db.Payments.Include(p => p.Student).ToList();
            foreach(var payment in list)
            {
                PaymentIndexView paymentIndexView = new PaymentIndexView
                {
                    Id = payment.PaymentId,
                    StudentName = payment.Student.Name,
                    Amount = payment.Total
                };
                payments.Add(paymentIndexView);
            }
            return payments;
        }


        public Payment UpdatePayment(Payment payment)
        {
            var paymentToUpdate = _db.Payments.Find(payment.PaymentId);
            paymentToUpdate.Total = payment.Total;
            _db.Payments.Update(paymentToUpdate);
            _db.SaveChanges();
            return payment;
        }


        public Payment RemovePayment(Payment payment)
        {
            _db.Payments.Remove(payment);
            _db.SaveChanges();
            return payment;
        }


        public Payment GetPaymentById(int id)
        {
            var payment = _db.Payments
                .Include(p => p.DetailsOfPayment)
                .Include(p => p.Student)
                .FirstOrDefault(p => p.PaymentId == id);
            _db.SaveChanges();
            return payment;
        }

        //PAYMENT DETAILS


        public PaymentDetails AddPaymentDetail(PaymentDetails pd)
        {
            _db.PaymentDetails.Add(pd);
            _db.SaveChanges();
            return pd;
        }

        public List<PaymentDetailsAjaxViewModel> GetAllPaymentDetails()
        {
            var allPaymentDetails = _db.PaymentDetails.Include(pd => pd.Payment).Include(pd => pd.Payment.Student).ToList();

            var details = new List<PaymentDetailsAjaxViewModel>();

            foreach(var detail in allPaymentDetails)
            {
                PaymentDetailsAjaxViewModel pd = new PaymentDetailsAjaxViewModel
                {
                    Id = detail.Id,
                    AmountPaid = detail.AmountPaid,
                    StudentName = detail.Payment.Student.Name,
                    Date = detail.Date
                };
                details.Add(pd);
            }
            return details;
        }


        public PaymentDetails UpdatePaymentDetails(PaymentDetails pd)
        {
            var pdToUpdate = _db.PaymentDetails.FirstOrDefault(p => p.Id == pd.Id);

            pdToUpdate.AmountPaid = pd.AmountPaid;
            pdToUpdate.Date = pd.Date;

            _db.PaymentDetails.Update(pdToUpdate);
            _db.SaveChanges();
            return pd;
        }


        public PaymentDetails GetPaymentDetailsById(int id)
        {
            return _db.PaymentDetails.Include(pd => pd.Payment).Include(pd => pd.Payment.Student).FirstOrDefault(pd => pd.Id == id);
        }


        public PaymentDetails RemovePaymentDetail(PaymentDetails pd)
        {
            _db.PaymentDetails.Remove(pd);
            _db.SaveChanges();
            return pd;
        }
    }
}
