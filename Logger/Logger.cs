using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger
    {
        FileWriter fileWriter;

        public Logger()
        {
            fileWriter = new FileWriter();
        }

        public void LogFunction(string functionName)
        {
            String record = String.Format("Running: {0}", functionName);
            fileWriter.Log(record);
        }
    }
}
