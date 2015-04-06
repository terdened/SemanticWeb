using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace DataEngine.Model
{
    public class Situation
    {
        #region private fields
        private const String defaultPath = @"c:\sws\situation.rdf";
        private String path;
        private Graph situation;
        private Logger.Logger logger;
        #endregion

        #region private methods
        private void LoadInGraph(String path)
        {
            RdfXmlParser ttlparser = new RdfXmlParser();

            try
            {
                ttlparser.Load(situation, path);
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
        }
        #endregion

        #region public methods
        public Situation(Logger.Logger logger)
        {
            this.logger = logger;
            situation = new Graph();
            path = defaultPath; 
            LoadInGraph(path);
        }

        public Situation(Graph situation, Logger.Logger logger)
        {
            this.logger = logger;
            this.situation = situation;
        }

        public Situation(String path, Logger.Logger logger)
        {
            this.logger = logger;
            this.path = path;
            LoadInGraph(path);
        }

        public SparqlResultSet ExecuteQuery(String query)
        {
            var results = situation.ExecuteQuery(query);
            return results is SparqlResultSet ? (SparqlResultSet)results : null;
        }

        public SparqlResultSet ExecuteQuery(SparqlQuery query)
        {
            var results = situation.ExecuteQuery(query);
            return results is SparqlResultSet ? (SparqlResultSet)results : null;
        }

        public void Save()
        {
            logger.LogFunction("WriteToFile");
            RdfXmlWriter rdfxmlwriter = new RdfXmlWriter();
            rdfxmlwriter.Save(situation, path);
        }
        #endregion

    }
}
