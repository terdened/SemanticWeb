using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEngine;

namespace Analyzer
{
    public class Analyzer
    {
        private List<IBaseHazard> hazards;
        private DataCore dataCore;

        public Analyzer(DataCore dataCore)
        {
            this.dataCore = dataCore;
            hazards = new List<IBaseHazard>();
            hazards.Add(new ThoughtcrimeHazard());
        }

        public bool Analyze()
        {
            bool result = false;

            foreach(var hazard in hazards)
            {
                if(hazard.Test())
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
