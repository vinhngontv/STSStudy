namespace Solid.DIP.After
{
    public interface ILog
    {
        void LogInfo(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void LogInfo(string msg)
        {
            // log info
        }
    }
    
    public class FileLog : ILog
    {
        public void LogInfo(string msg)
        {
            // log info
        }
    }
}