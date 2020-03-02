using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Model
{
    public interface IEmployeeRepository
    {
        //Students
        Student GetStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(Student student);

        //Guarantors
        Guarantor GetGuarantor(int Id);
        IEnumerable<Guarantor> GetAllGuarantors();
        Guarantor AddGuarantor(Guarantor guarantor);
        Guarantor UpdateGuarantor(Guarantor guarantor);
        Guarantor DeleteGuarantor(Guarantor guarantor);

        //Courses
        Course GetCourse(int courseId);
        IEnumerable<Course> GetAllCourses();
        Course AddCourse(Course course);
        Course UpdateCourse(Course course);
        Course DeleteCourse(Course course);

        //Batches
        Batch GetBatch(int batchId);
        IEnumerable<Batch> GetAllBatches();
        Batch AddBatch(Batch batch);
        Batch UpdateBatch(Batch batch);
        Batch DeleteBatch(Batch batch);

        //Programme
        Programme GetProgramme(int Id);
        IEnumerable<Programme> GetAllProgrammes();
        Programme AddProgramme(Programme programme);
        Programme UpdateProgramme(Programme programme);
        Programme DeleteProgramme(Programme programme);

        List<StudentCourse> GetStudentCourses(int id);
        List<ProgrammeCourse> GetProgrammeCourses(int id);

        bool AddProgrammeCourse(ProgrammeCourse c);
        bool RemoveProgrammeCourse(ProgrammeCourse c);

        List<ProgrammeCourse> GetProgrammeCourses_POnly(int id);
    }
}
