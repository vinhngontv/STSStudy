using Linq;

namespace Solid.DIP.Before
{
    public class StudentService
    {
        public void Insert(Student student)
        {
            Database db = new Database();
            db.Add(student);

            Logger log = new Logger();
            log.LogInfo("Add new student " + student.FullName);

            Notification notification = new Notification();
            notification.Send(student.FullName);
        }
    }

    public class Database
    {
        public void Add(Student student)
        {
            // todo add new student 
        }
    }
    
    public class Logger
    {
        public void LogInfo(string msg)
        {
            // todo log msg
        }
    }
    
    public class Notification
    {
        public void Send(string fullName)
        {
            // todo send new email
        }
    }
}