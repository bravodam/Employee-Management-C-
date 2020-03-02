using System;
using EmployeeManagement.Model;

namespace EmployeeManagement.ViewModels
{
    public class BatchDetailsViewModel : Batch
    {
        public BatchDetailsViewModel()
        {
        }

        public Programme Prog { get; set; }

    }
}
