using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTraining
{
    class ExpenseFactory
    {
        public static IAnalyser getComponent() => new Analyser();
    }
}
