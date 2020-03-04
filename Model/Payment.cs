using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Payment
    {
        public Payment()
        {
        }

        public int PaymentId { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public double Total { get; set; }

        public List<PaymentDetails> DetailsOfPayment{ get; set; }
    }
}
