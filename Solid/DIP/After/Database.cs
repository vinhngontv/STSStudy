using Linq;

namespace Solid.DIP.After
{
    public interface IDatabase
    {
        void Add(Student student);
    }

    public class MsSqlDB : IDatabase
    {
        public void Add(Student student)
        {
            // todo add new student
        }
    }
    
    public class MySqlDB : IDatabase
    {
        public void Add(Student student)
        {
            // todo add new student
        }
    }
}