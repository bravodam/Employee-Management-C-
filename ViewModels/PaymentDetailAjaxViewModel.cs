using System;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class PaymentDetailAjaxViewModel : PaymentDetails
    {
        public PaymentDetailAjaxViewModel()
        {
        }

        public int StudentId { get; set; }
    }
}
