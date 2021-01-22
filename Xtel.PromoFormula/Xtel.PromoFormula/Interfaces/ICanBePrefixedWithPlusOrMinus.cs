using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface ICanBePrefixedWithPlusOrMinus : IExpr, ICanBePrefixedWithPlus, ICanBePrefixedWithMinus
    {
    }
}
