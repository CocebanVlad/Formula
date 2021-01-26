using System.Collections.Generic;
using System.Linq;
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

        public BuildContext CreateCopy() => new BuildContext()
        {
            Index = Index,
            Tokens = Tokens.ToList(),
            BuiltExpressions = BuiltExpressions.ToList(),
        };

        public void RestoreFrom(BuildContext ctx)
        {
            Index = ctx.Index;
            Tokens = ctx.Tokens.ToList();
            BuiltExpressions = ctx.BuiltExpressions.ToList();
        }
    }
}
