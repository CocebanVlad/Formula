using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Environments
{
    public class FormulaEvalEnv : EvalEnv
    {
        public override IDictionary<string, Fn> Functions => new Dictionary<string, Fn>()
        {
        };
    }
}
