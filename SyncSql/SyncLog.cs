using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SyncLog
{
    public class Log
    {
        internal string _LogFileName;
        internal string _LogFileDir;

        public string LogFileDir { get { return _LogFileDir; } }
        public string LogFileName { get { return _LogFileName; } }

        public Log(string fileName)
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
            _LogFileName = fileName;
        }

        public Log(string fileName, string fileDirectory) : this(fileName)
        {
            _LogFileDir = fileDirectory;
        }

        /*
        public string Read()
        {
            return File.ReadAllText(LogFileDir + LogFileName);
        }
        */
        
        public string[] Read()
        {
            return File.ReadAllLines(LogFileDir + LogFileName);
        }
        

        public void WriteLine(string pString)
        {
            if (_LogFileDir != null)
            {
                if (!System.IO.Directory.Exists(_LogFileDir))
                {
                    System.IO.Directory.CreateDirectory(_LogFileDir);
                }

                if (_LogFileDir.Substring(_LogFileDir.Length - 1, 1) != @"\")
                {
                    _LogFileDir += @"\";
                }
            }

            if (File.Exists(_LogFileDir + _LogFileName))
            {
                using (StreamWriter streamWriter = File.AppendText(_LogFileDir + _LogFileName))
                {
                    streamWriter.WriteLine(pString);
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(_LogFileDir + _LogFileName, FileMode.Create))
                {

                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine("{0} - Log \"{1}\" did not exist. Log has been created", DateTime.Now.ToString(), _LogFileName);
                        streamWriter.WriteLine(pString);
                    }
                }

            }
        }

        public void Clear()
        {
            if (_LogFileDir != null)
            {
                if (!Directory.Exists(_LogFileDir))
                {
                    Directory.CreateDirectory(_LogFileDir);
                }

                if (_LogFileDir.Substring(_LogFileDir.Length - 1, 1) != @"\")
                {
                    _LogFileDir += @"\";
                }
            }
            File.WriteAllText(_LogFileDir + _LogFileName, String.Format("{0} - Log \"{1}\" was cleared!", DateTime.Now.ToString(), _LogFileName));
            WriteLine(""); //This is to stop the next line of the log being put on the same line as above
        }

        public void Delete()
        {
            File.Delete(_LogFileDir);
        }
    }
}
