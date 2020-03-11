using System;
namespace EmployeeManagement.ViewModels
{
    public class PaymentDetailsAjaxViewModel
    {
        public PaymentDetailsAjaxViewModel()
        {
        }

        public int Id { get; set; }

        public string StudentName { get; set; }

        public double AmountPaid { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
