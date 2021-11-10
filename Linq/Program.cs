using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Linq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentRepository(new SchoolContext());
            //Query(studentRepository);
            //LazyLoading();
            TreeExpression(studentRepository);
            //First(studentRepository);
            //FirstOrDefault(studentRepository);
            //Single(studentRepository);
            //SingleOrDefault(studentRepository);
        }

        private static void Query(IStudentRepository studentRepository)
        {
            var query = studentRepository.Get(x => x.FullName.Contains("sts"))
                .OrderByDescending(x => x.Yob).Take(10);

            IEnumerable<Student> students = studentRepository.Get(x => x.FullName.Contains("sts"));
            var result = students.Take(2);
        }

        private static void LazyLoading()
        {
            using (var ctx = new SchoolContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var grades = ctx.Grades.Where(x => x.GradeId < 3);
                foreach (var grade in grades)
                {
                    Console.WriteLine(grade.GradeName);
                    foreach (var student in grade.Students)
                    {
                        Console.WriteLine(student.FullName);
                    }
                }
            }
        }

        private static void TreeExpression(IStudentRepository studentRepository)
        {
            Expression<Func<Student, bool>> isMatch = x => x.Id > 1001 && x.Id < 1010;
            
            Console.WriteLine("Expression: {0}", isMatch );
        
            Console.WriteLine("Expression Type: {0}", isMatch.NodeType);
            
            var parameters = isMatch.Parameters;

            foreach (var param in parameters)
            {
                Console.WriteLine("Parameter Name: {0}", param.Name);
                Console.WriteLine("Parameter Type: {0}", param.Type.Name );
            }
            var bodyExpr = isMatch.Body as BinaryExpression;

            Console.WriteLine("Left side of body expression: {0}", bodyExpr.Left);
            Console.WriteLine("Binary Expression Type: {0}", bodyExpr.NodeType);
            Console.WriteLine("Right side of body expression: {0}", bodyExpr.Right);
            Console.WriteLine("Return Type: {0}", isMatch.ReturnType);

            var query = studentRepository.Get(isMatch);
            Console.WriteLine(query);

            var students = query.ToList();
        }

        private static List<Student> GetStudent(IStudentRepository studentRepository)
        {
            return studentRepository.Get().ToList();
        }

        private static void First(IStudentRepository studentRepository)
        {
            var students = GetStudent(studentRepository);
            
            students = students.Where(x => x.FullName.Contains("1"))
                .OrderByDescending(x => x.Yob).ToList();
            var student1 = students.First();
            var student2 = students.First(x => x.Id == 1001);
            
            var student3 = students.Where(x => x.Id == 0)
                .OrderByDescending(x => x.Yob).First();
        }
        
        private static void FirstOrDefault(IStudentRepository studentRepository)
        {
            var students = GetStudent(studentRepository);
            
            students = students.Where(x => x.FullName.Contains("1"))
                .OrderByDescending(x => x.Yob).ToList();
            var student1 = students.FirstOrDefault();
            
            var student2 = students.FirstOrDefault(x => x.Id == 1001);
            
            var student3 = students.Where(x => x.Id == 0)
                .OrderByDescending(x => x.Yob).FirstOrDefault();
        }
        
        private static void Single(IStudentRepository studentRepository)
        {
            var students = GetStudent(studentRepository);
            
            students = students.Where(x => x.FullName.Contains("1"))
                .OrderByDescending(x => x.Yob).ToList();
            var student2 = students.Single(x => x.Id == 1001);

            var student1 = students.Single();
            
            var student3 = students.Where(x => x.Id == 0)
                .OrderByDescending(x => x.Yob).Single();
        }
        
        private static void SingleOrDefault(IStudentRepository studentRepository)
        {
            var students = GetStudent(studentRepository);
            
            students = students.Where(x => x.FullName.Contains("1"))
                .OrderByDescending(x => x.Yob).ToList();
            
            var student2 = students.SingleOrDefault(x => x.Id == 1001);

            var student3 = students.Where(x => x.Id == 0)
                .OrderByDescending(x => x.Yob).SingleOrDefault();
            
            var student1 = students.SingleOrDefault();
        }
    }
} 