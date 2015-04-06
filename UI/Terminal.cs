using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using VDS.RDF;

namespace UI
{
    class Terminal
    {
        static void Main(string[] args)
        {
            Logger.Logger logger = new Logger.Logger();
            var helloWorld = new DataEngine.HelloWorld(logger);
            var person = helloWorld.DescribePerson();
            Console.WriteLine(helloWorld.GraphToString(person));
            Console.ReadLine();
        }
    }
}
