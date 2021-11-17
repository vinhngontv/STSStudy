namespace Solid.DIP.After
{
    public interface INotification
    {
        void Send(string fullName);
    }

    public class MailSender : INotification
    {
        public void Send(string fullName)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class InAppNotification : INotification
    {
        public void Send(string fullName)
        {
            throw new System.NotImplementedException();
        }
    }
}