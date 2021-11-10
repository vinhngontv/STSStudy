using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Linq
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("mssql")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Student>()
                .HasRequired<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey<int>(s => s.GradeId);          
        }
    
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
    public class Student
    { 
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Sex { get; set; }
        public DateTime Yob { get; set; }
        public string PhoneNumber { get; set; }
        
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
}