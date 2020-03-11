using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Model
{
    public interface IPayment
    {
        Payment AddPayment(Payment payment);
        Payment UpdatePayment(Payment payment);
        Payment RemovePayment(Payment payment);
        Payment GetPaymentById(int id);
        List<PaymentIndexView> GetAllPayment();

        PaymentDetails AddPaymentDetail(PaymentDetails pd);
        PaymentDetails UpdatePaymentDetails(PaymentDetails pd);
        PaymentDetails RemovePaymentDetail(PaymentDetails pd);
        PaymentDetails GetPaymentDetailsById(int id);
        List<PaymentDetailsAjaxViewModel> GetAllPaymentDetails();
    }
}
