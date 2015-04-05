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
            Console.WriteLine(helloWorld.SayHello());
            Console.WriteLine("Input .RDF file path");
            var path = Console.ReadLine();
            var graph = helloWorld.ParseToGraph(path.ToString());
            Console.WriteLine(helloWorld.GraphToString(graph));
            Console.ReadLine();
        }
    }
}
