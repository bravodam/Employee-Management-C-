using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class ProjectRepo : IProject
    {
        private readonly AppDbContext _db;

        public ProjectRepo(AppDbContext db)
        {
            _db = db;
        }

        public Project AddProject(Project p)
        {
            _db.Projects.Add(p);
            _db.SaveChanges();
            return p;

        }

        
        // PROJECT
        public List<Project> GetAllProjects()
        {
            return _db.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            throw new NotImplementedException();
        }


        public Project RemoveProject(Project p)
        {
            throw new NotImplementedException();
        }

        public Project UpdateProject(Project p)
        {
            throw new NotImplementedException();
        }


        // STUDENTPROJECT
        public StudentProject AddStudentProject(StudentProject sp)
        {
            _db.StudentProjects.Add(sp);
            _db.SaveChanges();
            return sp;
        }


        public List<StudentProject> GetStudentProjectByProjectId(int id)
        {
            var list = _db.StudentProjects
                .Include(sp => sp.Student)
                .Include(sp => sp.Project)
                .Where(sp => sp.ProjectId == id).ToList();
            return list;
        }

        public List<StudentProject> GetStudentProjectByStudentId(int id)
        {
            var list = _db.StudentProjects
                .Include(sp => sp.Student)
                .Include(sp => sp.Project)
                .Where(sp => sp.StudentId == id).ToList();
            return list;
        }
    }
}
