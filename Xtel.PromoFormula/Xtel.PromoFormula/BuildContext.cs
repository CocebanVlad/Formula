using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public class BuildContext
    {
        public int Index { get; private set; } = 0;
        public IList<IToken> Tokens { get; set; }
        public IToken Token => HasToken() ? Tokens[Index] : null;
        public IList<IExpr> BuiltExpressions { get; set; }

        public void MoveToTheNextIndex() => Index++;
        public void ResetIndex() => Index = 0;
        public bool HasToken() => Index < Tokens.Count;
    }
}
