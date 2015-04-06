using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEngine;

namespace Analyzer
{
    abstract class BaseHazard : IBaseHazard
    {
        protected String query;

        public abstract bool Test(DataCore dataCore);
    }
}
