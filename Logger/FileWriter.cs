using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class FileWriter
    {
        private String path;
        private String filename;
        private String extention;
        
        private String GetFullpath()
        {
            return path + filename + extention;
        }

        public FileWriter()
        {
            path = String.Format(@"C:\SemanticWebLogs\{0}\", DateTime.UtcNow.ToShortDateString()).Replace('/',' ');
            new FileInfo(path).Directory.Create();
            extention = ".log";
            filename = DateTime.Now.ToLongTimeString().Replace(':', ' ');
        }

        public void Log(String record)
        {
            var path = GetFullpath();
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(record);
            file.Close();
        }

        public void Log(IEnumerable<String> records)
        {
            StreamWriter file = new StreamWriter(GetFullpath(), true);

            foreach(var record in records)
                file.WriteLine(record);

            file.Close();
        }

        public void NewLog()
        {
            filename = DateTime.Now.ToShortTimeString().Replace(':', ' ');
        }
    }
}
