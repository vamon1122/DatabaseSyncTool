using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SyncSql.Logging
{
    public static class Logs
    {
        public static readonly Log SyncLog = new Log("SyncLog");
        public static readonly Log ProvisioningLog = new Log("ProvisioningLog");
    }

    public class Log
    {
        internal string logFileName;
        internal string logFileDirectory;

        public string LogFileDirectory { get { return logFileDirectory; } }
        public string LogFileName { get { return logFileName; } }

        internal Log(string fileName)
        {
            if (fileName.Contains('.'))
            {
                if(fileName.Split('.').Last() != "txt")
                {
                    fileName += ".txt";
                }
            }
            else
            {
                fileName += ".txt";
            }
            logFileName = fileName;
        }

        internal Log(string fileName, string fileDirectory) : this(fileName)
        {
            logFileDirectory = fileDirectory;
        }
        
        public string[] Read()
        {
            return File.ReadAllLines(LogFileDirectory + LogFileName);
        }

        public void WriteLine(string pString)
        {
            if (logFileDirectory != null)
            {
                if (!System.IO.Directory.Exists(logFileDirectory))
                {
                    System.IO.Directory.CreateDirectory(logFileDirectory);
                }

                if (logFileDirectory.Substring(logFileDirectory.Length - 1, 1) != @"\")
                {
                    logFileDirectory += @"\";
                }
            }

            if (File.Exists(logFileDirectory + logFileName))
            {
                using (StreamWriter streamWriter = File.AppendText(logFileDirectory + logFileName))
                {
                    streamWriter.WriteLine(pString);
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(logFileDirectory + logFileName, FileMode.Create))
                {

                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine("{0} - Log \"{1}\" did not exist. Log has been created", DateTime.Now.ToString(), logFileName);
                        streamWriter.WriteLine(pString);
                    }
                }

            }
        }

        public void Clear()
        {
            if (logFileDirectory != null)
            {
                if (!Directory.Exists(logFileDirectory))
                {
                    Directory.CreateDirectory(logFileDirectory);
                }

                if (logFileDirectory.Substring(logFileDirectory.Length - 1, 1) != @"\")
                {
                    logFileDirectory += @"\";
                }
            }
            File.WriteAllText(logFileDirectory + logFileName, String.Format("{0} - Log \"{1}\" was cleared!", DateTime.Now.ToString(), logFileName));
            WriteLine(""); //This is to stop the next line of the log being put on the same line as above
        }

        public void Delete()
        {
            File.Delete(logFileDirectory);
        }
    }
}
