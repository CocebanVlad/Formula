using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class EvalEnv
    {
        public abstract IDictionary<string, Fn> Functions { get; }
    }
}
