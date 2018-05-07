using System;
using System.IO;
using System.Text;

namespace SingletonLoggerApp
{
    public class SingletonLogger
    {

        private const string WRITE_PATH = @"C:\Users\User\Downloads\testLogger.log";
        private const string DATATIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private static SingletonLogger instance = new SingletonLogger();

        private SingletonLogger() { }

        public static SingletonLogger GetInstance()
        {
            CurrentPath = SetLogFile();
            return instance;
        }

        private static string CurrentPath { get; set; }
        private static string SetLogFile()
        {
            FileInfo fi = new FileInfo(WRITE_PATH);
            if (!fi.Exists)
            {
                FileStream fs = fi.Create();
                fs.Close();
                return WRITE_PATH;
            }
            else
            {
                int number = 1;
                string path = @"C:\Users\User\Downloads\testLogger" + number + ".log";
                FileInfo fi1 = new FileInfo(path);
                while (fi1.Exists)
                {
                    number++;
                    path = @"C:\Users\User\Downloads\testLogger" + number + ".log";
                    fi1 = new FileInfo(path);
                }
                FileStream fs = fi1.Create();
                fs.Close();
                return path;
            }
 
        }

        public static void PushToLogTrace<T>(T info)
        {
            var data = DateTime.Now.ToString(DATATIME_FORMAT) + " " + info;
            try
            {
                using (StreamWriter sw = new StreamWriter(CurrentPath, true, Encoding.Default))
                {
                    sw.WriteLine(data);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
