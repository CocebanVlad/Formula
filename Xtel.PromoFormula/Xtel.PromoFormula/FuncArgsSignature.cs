using System.Collections.Generic;
using System.Linq;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public class FuncArgsSignature : List<Enums.Type>, IFuncArgsSignature
    {
        public bool Equals(IFuncArgsSignature other) => other != null && this.SequenceEqual(other);
    }
}
