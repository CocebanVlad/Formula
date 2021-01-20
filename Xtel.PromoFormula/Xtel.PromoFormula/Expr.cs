﻿using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Expr : IExpr
    {
        public abstract int IdxS { get; }
        public abstract int IdxE { get; }

        public abstract object Eval(IEvalEnv env);
    }
}
