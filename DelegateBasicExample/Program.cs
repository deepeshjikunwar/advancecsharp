namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text); //delegate reference method with one string parameter and doesn't return a value

        delegate void LogDel2(string text, DateTime dateTime);
        static void Main(string[] args)
        {
            LogDel logDel = new LogDel(LogTextToScreeen);
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();
            logDel(name);

            LogDel2 logDel2 = new LogDel2(LogTextToScreen2);
            Console.WriteLine("Enter name2: ");
            var name2 = Console.ReadLine();
            logDel2.Invoke(name2, DateTime.Now);

            LogDel logDel3 = new LogDel(LogTextToFile);
            Console.WriteLine("Enter name3: ");
            var name3 = Console.ReadLine();
            logDel3(name3);

            Log log = new Log();
            LogDel logDel4 = new LogDel(log.LogTextToScreeen);
            Console.WriteLine("Enter name4: ");
            var name4 = Console.ReadLine();
            logDel2.Invoke(name4, DateTime.Now);

            LogDel LogTextToScreenDel, LogTextToFileDel;
            LogTextToScreenDel = new LogDel(log.LogTextToScreeen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);
            LogDel MultiLogDel = LogTextToScreenDel + LogTextToFileDel;
            Console.WriteLine("Enter name5: ");
            var name5 = Console.ReadLine();
            MultiLogDel(name5);

            Console.WriteLine("Enter name6: ");
            var name6 = Console.ReadLine();
            LogText(MultiLogDel, name6);

        }

        static void LogTextToScreeen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        static void LogTextToScreen2(string text, DateTime dateTime)
        {
            Console.WriteLine($"{dateTime}: {text}");
        }

        static void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    public class Log
    {
        public void LogTextToScreeen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
