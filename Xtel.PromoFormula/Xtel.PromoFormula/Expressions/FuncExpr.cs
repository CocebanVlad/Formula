using CalculationService.Interfaces;
using CalculationService.Tokens;
using System.Collections.Generic;

namespace CalculationService.Expressions
{
    public class FuncExpr : Expr, ICanBePrefixedWithPlusOrMinus, ICanBeNegated
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

        public object ApplyPlus() => Helpers.ApplyPlus(this);

        public object ApplyMinus() => Helpers.ApplyMinus(this);

        public object Negate() => Helpers.Negate(this);

        public override object Eval() => Func.Exec(Env, Args);

        public override string GetAsString() => Helpers.ToString(Eval());
    }
}
