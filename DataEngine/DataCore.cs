using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEngine.Model;
using Logger;
using VDS.RDF.Query;

namespace DataEngine
{
    class DataCore
    {
        private Situation situation;
        private Logger.Logger logger;
        
        public DataCore (Logger.Logger logger)
        {
            situation = new Situation(logger);
        }

        public SparqlResultSet ExecuteQuery(String query)
        {
            var results = situation.ExecuteQuery(query);
            return results is SparqlResultSet ? (SparqlResultSet)results : null;
        } 
    }
}
