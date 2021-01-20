using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Fn : IFn
    {
        public abstract object Exec(object[] args);
    }
}
