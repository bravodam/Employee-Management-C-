using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Model
{
    public interface IPayment
    {
        Payment AddPayment(Payment payment);
        Payment UpdatePayment(Payment payment);
        Payment RemovePayment(Payment payment);
        Payment GetPaymentById(int id);
        List<Payment> GetAllPayment(int id);

        PaymentDetails AddPaymentDetail(PaymentDetails pd);
        PaymentDetails EditPaymentDetails(PaymentDetails pd);
        PaymentDetails RemovePaymentDetails(PaymentDetails pd);
        PaymentDetails GetPaymentDetailsById(int id);
        List<PaymentDetails> GetAllPaymentDetail(int id);
    }
}
