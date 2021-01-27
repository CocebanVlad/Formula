using System.Collections.Generic;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class FuncExpr : Expr
    {
        public LiteralToken Token { get; set; }
        public ParenthesisToken ArgsBlockOpenToken { get; set; }
        public ParenthesisToken ArgsBlockCloseToken { get; set; }
        public IFunc Func { get; set; }
        public IList<IExpr> Args { get; } = new List<IExpr>();

        public override int IdxS => Token.IdxS;
        public override int IdxE => ArgsBlockCloseToken.IdxE;
        public override Enums.Type ReturnType => Func.ReturnType;

        public FuncExpr(IEnv env)
            : base(env)
        {
        }

        public override object Eval() => Func.Exec(Args);

        public override string GetAsString() => Helpers.ToString(Eval());
    }
}
