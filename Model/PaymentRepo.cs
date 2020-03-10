using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<PaymentDetails> GetAllPaymentDetail(int id)
        {
            throw new NotImplementedException();
        }


        public PaymentDetails EditPaymentDetails(PaymentDetails pd)
        {
            throw new NotImplementedException();
        }


        public PaymentDetails GetPaymentDetailsById(int id)
        {
            throw new NotImplementedException();
        }


        public PaymentDetails RemovePaymentDetails(PaymentDetails pd)
        {
            throw new NotImplementedException();
        }
    }
}
