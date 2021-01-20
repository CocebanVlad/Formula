using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Environments
{
    public class FormulaEvalEnv : EvalEnv
    {
        public override IDictionary<string, IFn> Functions => new Dictionary<string, IFn>()
        {
        };
    }
}
