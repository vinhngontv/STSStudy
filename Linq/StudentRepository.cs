using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Linq
{
    public interface IStudentRepository : IDisposable
    {
        IQueryable<Student> Get(Expression<Func<Student, bool>> expression = null);
        Student GetById(int id);
        void Insert(Student student);
        void Delete(int id);
        void Update(Student student);
        void Save();
    }
    
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private SchoolContext _context;
        private bool disposed = false;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }
        
        public IQueryable<Student> Get(Expression<Func<Student, bool>> expression = null)
        {
            var query = _context.Set<Student>().AsNoTracking();
            return expression == null ? query : query.Where(expression);
        }
        
        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}