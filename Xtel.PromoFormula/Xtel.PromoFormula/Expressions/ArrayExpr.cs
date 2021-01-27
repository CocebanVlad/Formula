using System.Collections.Generic;
using System.Linq;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class ArrayExpr : Expr
    {
        private Enums.Type _returnType =
            Enums.Type.Array;

        public ArrayParenthesisToken OpenToken { get; set; }
        public ArrayParenthesisToken CloseToken { get; set; }
        public IList<IExpr> Elements { get; }
            = new List<IExpr>();

        public override int IdxS => OpenToken.IdxS;
        public override int IdxE => CloseToken.IdxE;
        public override Enums.Type ReturnType => _returnType;

        public ArrayExpr(IEnv env)
            : base(env)
        {
        }

        public void IdentifyExactReturnType() =>
            _returnType = Helpers.GetArrayType(Elements);

        public override object Eval() =>
            Helpers.ToArray(Elements.Select(expr => expr.Eval()), _returnType);

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() =>
            $"{OpenToken}{string.Join(",", Elements.Select(expr => expr.ToString()))}{CloseToken}";
    }
}
