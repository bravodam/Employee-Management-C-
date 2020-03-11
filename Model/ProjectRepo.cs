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
            return _db.Projects.Include(p => p.StudentProjects)
                .FirstOrDefault(p => p.ProjectId == id);
        }


        public Project RemoveProject(Project p)
        {
            _db.Projects.Remove(p);
            _db.SaveChanges();
            return p;
        }

        public Project UpdateProject(Project p)
        {
            var projectToUpdate = _db.Projects.FirstOrDefault(p => p.ProjectId == p.ProjectId);

            projectToUpdate.Description = p.Description;
            projectToUpdate.Title = p.Title;
            projectToUpdate.GitUrl = p.GitUrl;

            _db.Projects.Update(projectToUpdate);
            _db.SaveChanges();
            return p;
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
