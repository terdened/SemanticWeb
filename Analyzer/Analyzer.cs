using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    public class Analyzer
    {
        List<IBaseHazard> hazards;

        public Analyzer()
        {
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
