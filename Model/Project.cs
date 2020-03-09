using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Project
    {
        public Project()
        {
        }

        public int ProjectId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string GitUrl { get; set; }

        public List<StudentProject> StudentProjects { get; set; }

    }
}
