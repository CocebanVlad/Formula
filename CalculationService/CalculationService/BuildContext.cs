using CalculationService.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CalculationService
{
    public class BuildContext : IRestorable<BuildContext>
    {
        public int Idx { get; private set; }
        public IList<IToken> Tokens { get; private set; }
        public IList<IExpr> BuiltExprs { get; private set; }

        public bool HasToken => Idx < Tokens.Count;
        public IToken Token => HasToken ? Tokens[Idx] : null;
        public int LastExprIdx => BuiltExprs.Count - 1;
        public IExpr LastExpr => LastExprIdx > -1 ? BuiltExprs[LastExprIdx] : null;

        private BuildContext()
        {
        }

        public BuildContext(IList<IToken> tokens)
        {
            Idx = 0;
            Tokens = tokens;
            BuiltExprs = new List<IExpr>();
        }

        public BuildContext CreateCopy() => new BuildContext()
        {
            Idx = Idx,
            Tokens = Tokens.ToList(),
            BuiltExprs = BuiltExprs.ToList(),
        };

        public void RestoreFrom(BuildContext copy)
        {
            Idx = copy.Idx;
            Tokens = copy.Tokens.ToList();
            BuiltExprs = copy.BuiltExprs.ToList();
        }

        public void NextIndex() => Idx++;

        public void ResetIndex() => Idx = 0;

        public void PushExpr(IExpr expr) => BuiltExprs.Add(expr);

        public IExpr PopExpr()
        {
            if (BuiltExprs.Count > 0)
            {
                var expr = LastExpr;
                BuiltExprs.RemoveAt(LastExprIdx);
                return expr;
            }

            return null;
        }
    }
}
