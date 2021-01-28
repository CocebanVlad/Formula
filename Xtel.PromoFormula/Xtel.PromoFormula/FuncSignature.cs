using System.Collections.Generic;
using System.Linq;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public class FuncSignature : List<Enums.Type>, IFuncSignature
    {
        public bool Equals(IFuncSignature other) => other != null && this.SequenceEqual(other);
    }
}
