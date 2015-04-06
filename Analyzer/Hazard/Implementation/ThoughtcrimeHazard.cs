using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    class ThoughtcrimeHazard : BaseHazard
    {
        public ThoughtcrimeHazard()
        {
            this.query = "Thoughtcrime is death";
        }

        override public bool Test()
        {
            return true;
        }
    }
}
