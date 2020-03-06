using System;
using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    public interface IProject
    {
        Project AddProject(Project p);
        Project UpdateProject(Project p);
        Project RemoveProject(Project p);
        Project GetProjectById(int id);
        List<Project> GetAllProjects();

        StudentProject AddStudentProject(StudentProject sp);
        List<StudentProject> GetStudentProjectByStudentId(int id);
        List<StudentProject> GetStudentProjectByProjectId(int id);
    }
}
