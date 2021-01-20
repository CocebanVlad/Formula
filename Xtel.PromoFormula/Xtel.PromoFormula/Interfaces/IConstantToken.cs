using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IConstantToken : IToken
    {
        object GetValue();
    }
}
