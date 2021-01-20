using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class EvalEnv : IEvalEnv
    {
        public abstract IDictionary<string, IFn> Functions { get; }

        public object ExecFn(in string name, object[] args) => Functions[name].Exec(args);
    }
}
