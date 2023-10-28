using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Loggers
{
    public class LogWriter
    {
        public LogWriter(string logMessage, string path)
        {
            LogWrite(logMessage, path);
        }
        public void LogWrite(string logMessage, string path)
        {
            try
            {
                string fullPath = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd"), "log.txt");

                // Get the directory path
                string directoryPath = Path.GetDirectoryName(fullPath);

                // Check if the directory exists, and if not, create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (!File.Exists(fullPath))
                {
                    File.Create(fullPath).Close();
                }

                // Create a FileStream for writing (you can use FileMode.Append if you want to append to the existing file)

                using (FileStream fileStream = File.Open(fullPath, FileMode.Append, FileAccess.Write))
                {
                    // Write to the file
                    byte[] data = Encoding.UTF8.GetBytes(logMessage);
                    fileStream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
