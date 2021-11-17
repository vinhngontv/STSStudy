using Linq;

namespace Solid.DIP.After
{
    public class StudentService
    {
        public void Insert(Student student)
        {
            IDatabase db = new MsSqlDB();
            //IDatabase db = new MySqlDB();
            db.Add(student);

            ILog log = new ConsoleLog();
            //ILog log = new FileLog();
            log.LogInfo("Add new student " + student.FullName);

            INotification notification = new MailSender();
            //INotification notification = new InAppNotification();
            notification.Send(student.FullName);
        }
    }
}