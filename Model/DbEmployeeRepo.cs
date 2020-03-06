    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class DbEmployeeRepo : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public DbEmployeeRepo(AppDbContext db)
        {
            _db = db;
        }

        public Student AddStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public Student DeleteStudent(Student student)
        {
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Students;
        }

        public Student GetStudent(int Id)
        {
            return _db.Students
                .Include(s => s.StudentBatches)
                .Include(s => s.StudentProjects)
                .Include(s => s.Payment)
                .Include(s => s.Payment.DetailsOfPayment)
                .FirstOrDefault(s => s.StudentId == Id);
        }

        public Student UpdateStudent(Student student)
        {
            _db.Students.Update(student);
            _db.SaveChanges();
            return student;
        }

        public void Test()
        {
           var x = _db.Programmes.Find(2);
        }

        // Guarantor methods
        public Guarantor AddGuarantor(Guarantor guarantor)
        {
            _db.Guarantors.Add(guarantor);
            _db.SaveChanges();
            return guarantor;
        }

        public Guarantor DeleteGuarantor(Guarantor guarantor)
        {
            _db.Guarantors.Remove(guarantor);
            _db.SaveChanges();
            return guarantor;
        }

        public IEnumerable<Guarantor> GetAllGuarantors()
        {
            return _db.Guarantors;
        }

        public Guarantor GetGuarantor(int Id)
        {
            return _db.Guarantors.Find(Id);
        }

        public Guarantor UpdateGuarantor(Guarantor guarantor)
        {
            _db.Guarantors.Update(guarantor);
            _db.SaveChangesAsync();
            return guarantor;
        }

        // Course methods
        public Course AddCourse(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }

        public Course DeleteCourse(Course course)
        {
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _db.Courses;
        }

        public Course GetCourse(int Id)
        {
            return _db.Courses.Find(Id);
        }

        public Course UpdateCourse(Course course)
        {
            _db.Courses.Update(course);
            _db.SaveChangesAsync();
            return course;
        }

        //ManyToMany
        public bool AddProgrammeCourse(ProgrammeCourse c)
        {
            _db.ProgrammeCourses.Add(c);
            _db.SaveChanges();
            return true;

        }

        public bool RemoveProgrammeCourse(ProgrammeCourse c)
        {
            _db.ProgrammeCourses.Remove(c);
            _db.SaveChanges();
            return true;

        }

        public List<StudentCourse> GetStudentCourses(int id)
        {
            List<StudentCourse> studentCourses = _db
                .StudentCourses
                .Include(item => item.Course)
                .Where(cm => cm.StudentId == id)
                .ToList();

            return studentCourses;
        }


        public List<ProgrammeCourse> GetProgrammeCourses(int id)
        {
            List<ProgrammeCourse> programmeCourses = _db
                .ProgrammeCourses
                .Include(item => item.Course)
                .Include(item => item.Programme)
                .Where(cm => cm.ProgrammeId == id)
                .ToList();

            return programmeCourses;
        }

        public List<ProgrammeCourse> GetProgrammeCourses_POnly(int id)
        {
            List<ProgrammeCourse> programmeCourses = _db
                .ProgrammeCourses
                .Include(item => item.Programme)
                .Where(cm => cm.CourseId == id)
                .ToList();

            return programmeCourses;
        }


        //BATCH
        public Batch AddBatch(Batch batch)
        {
            _db.Batches.Add(batch);
            _db.SaveChanges();
            return batch;
        }

        public IEnumerable<Batch> GetAllBatches()
        {
            return _db.Batches.Include(b => b.Programme).Include(b => b.StudentBatches);
        }

        public Batch GetBatch(int id)
        {
            return _db.Batches.Include(b => b.Programme).First(b => b.Id == id);
        }

        public Batch UpdateBatch(Batch batch)
        {
            _db.Batches.Update(batch);
            _db.SaveChanges();
            return batch;
        }

        public Batch DeleteBatch(Batch batch)
        {
            _db.Batches.Remove(batch);
            _db.SaveChanges();
            return batch;
        }

        //PROGRAM
        public Programme AddProgramme(Programme programme)
        {
            _db.Programmes.Add(programme);
            _db.SaveChanges();
            return programme;
        }

        public IEnumerable<Programme> GetAllProgrammes()
        {
            return _db.Programmes;
        }

        public Programme GetProgramme(int id)
        {
            return _db.Programmes.Find(id);
        }

        public Programme UpdateProgramme(Programme programme)
        {
            _db.Programmes.Update(programme);
            _db.SaveChanges();
            return programme;
        }

        public Programme DeleteProgramme(Programme programme)
        {
            _db.Programmes.Remove(programme);
            _db.SaveChanges();
            return programme;
        }
    }
}
