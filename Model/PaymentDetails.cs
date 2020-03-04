using System;
namespace EmployeeManagement.Model
{
    public class PaymentDetails
    {
        public PaymentDetails()
        {
        }

        public int Id { get; set; }

        public double AmountPaid { get; set; }

        public DateTimeOffset Date { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
