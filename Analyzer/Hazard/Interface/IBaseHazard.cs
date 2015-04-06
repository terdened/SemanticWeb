using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEngine;

namespace Analyzer
{
    public interface IBaseHazard
    {
        bool Test(DataCore dataCore);
    }
}
