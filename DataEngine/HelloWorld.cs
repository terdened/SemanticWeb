using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
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

            return result;
        }

        public IGraph SayHelloGraph()
        {
            logger.LogFunction("SayHello IGraph");
            Graph g = new Graph();

            IUriNode dotNetRDF = g.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
            IUriNode says = g.CreateUriNode(UriFactory.Create("http://example.org/says"));
            ILiteralNode helloWorld = g.CreateLiteralNode("Hello World");
            ILiteralNode bonjourMonde = g.CreateLiteralNode("Bonjour tout le Monde", "fr");

            g.Assert(new Triple(dotNetRDF, says, helloWorld));
            g.Assert(new Triple(dotNetRDF, says, bonjourMonde));

            return g;
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

        public void WriteToFile(IGraph graph, String path)
        {
            logger.LogFunction("WriteToFile");
            RdfXmlWriter rdfxmlwriter = new RdfXmlWriter();
            rdfxmlwriter.Save(graph, path);
        }

        public IGraph DescribePerson()
        {
            logger.LogFunction("DescribePerson");
            //First define a SPARQL Endpoint for DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));

            //Next define our query
            //We're going to ask DBPedia to describe the first thing it finds which is a Person
            String query = "DESCRIBE ?person WHERE {?person a <http://dbpedia.org/ontology/Person>} LIMIT 1";

            //Get the result
            return endpoint.QueryWithResultGraph(query);
        }

    }
}
