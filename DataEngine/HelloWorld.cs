using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using System.IO;

namespace DataEngine
{
    public class HelloWorld
    {
        Logger.Logger logger;

        public HelloWorld(Logger.Logger logger)
        {
            this.logger = logger;
        }

        public String SayHello()
        {
            logger.LogFunction("SayHello");
            var result = "";
            Graph g = new Graph();

            IUriNode dotNetRDF = g.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
            IUriNode says = g.CreateUriNode(UriFactory.Create("http://example.org/says"));
            ILiteralNode helloWorld = g.CreateLiteralNode("Hello World");
            ILiteralNode bonjourMonde = g.CreateLiteralNode("Bonjour tout le Monde", "fr");

            g.Assert(new Triple(dotNetRDF, says, helloWorld));
            g.Assert(new Triple(dotNetRDF, says, bonjourMonde));

            foreach (Triple t in g.Triples)
            {
                result += t.ToString() + "\n";
            }

            NTriplesWriter ntwriter = new NTriplesWriter();
            ntwriter.Save(g, "HelloWorld.nt");

            RdfXmlWriter rdfxmlwriter = new RdfXmlWriter();
            rdfxmlwriter.Save(g, "HelloWorld.rdf");

            return result;
        }

        public IGraph ParseToGraph(String path)
        {
            logger.LogFunction("ParseToGraph");
            IGraph graph = new Graph();
            TurtleParser ttlparser = new TurtleParser();


            try
            {
                ttlparser.Load(graph, path);
            }
            catch (RdfParseException parseEx)
            {
                //This indicates a parser error e.g unexpected character, premature end of input, invalid syntax etc.
                logger.LogFunction("Parser Error");
                logger.LogFunction(parseEx.Message);
            }
            catch (RdfException rdfEx)
            {
                //This represents a RDF error e.g. illegal triple for the given syntax, undefined namespace
                logger.LogFunction("RDF Error");
                logger.LogFunction(rdfEx.Message);
            }
            catch (Exception ex)
            {
                logger.LogFunction("Unknown Error");
                logger.LogFunction(ex.Message);
            }

            

            return graph;
        }

        public string GraphToString(IGraph graph)
        {
            logger.LogFunction("GraphToString");
            var result = "";

            foreach (Triple t in graph.Triples)
            {
                result += t.ToString() + "\n";
            }

            return result;
        }
    }
}
