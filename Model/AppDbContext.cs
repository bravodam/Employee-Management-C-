using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }
        public DbSet<StudentGuarantor> StudentGuarantor { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Batch> Batches { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Salary> Salaries { get; set; }



        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<ProgrammeCourse> ProgrammeCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Student Course Relationship */
            modelBuilder.Entity<StudentCourse>()
            .HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sg => sg.Student)
                .WithMany(sg => sg.StudentCourses)
                .HasForeignKey(sg => sg.StudentId);


            modelBuilder.Entity<StudentCourse>()
                .HasOne(sg => sg.Course)
                .WithMany(sg => sg.StudentCourses)
                .HasForeignKey(sg => sg.CourseId);




            /* Student Guarantor Relationship */
            modelBuilder.Entity<StudentGuarantor>()
            .HasKey(x => new { x.StudentId, x.GuarantorId });

            modelBuilder.Entity<StudentGuarantor>()
                .HasOne(sg => sg.Student)
                .WithMany(sg => sg.StudentGuarantors)
                .HasForeignKey(sg => sg.StudentId);


            modelBuilder.Entity<StudentGuarantor>()
                .HasOne(sg => sg.Guarantor)
                .WithMany(sg => sg.StudentGuarantors)
                .HasForeignKey(sg => sg.GuarantorId);




            /* Programe Course Relationship */
            modelBuilder.Entity<ProgrammeCourse>()
            .HasKey(x => new { x.ProgrammeId, x.CourseId });

            modelBuilder.Entity<ProgrammeCourse>()
                .HasOne(sg => sg.Programme)
                .WithMany(sg => sg.ProgrammeCourses)
                .HasForeignKey(sg => sg.ProgrammeId);


            modelBuilder.Entity<ProgrammeCourse>()
                .HasOne(sg => sg.Course)
                .WithMany(sg => sg.ProgrammeCourses)
                .HasForeignKey(sg => sg.CourseId);



            ///* Batch Student Relationship */
            modelBuilder.Entity<Student>()
                .HasOne(sg => sg.Batch)
                .WithMany(sg => sg.StudentsInBatch);

            ///* Batch Programme Relationship */
            modelBuilder.Entity<Batch>()
                .HasOne(sg => sg.Programme)
                .WithMany(sg => sg.Batches);
        }

    }
}
