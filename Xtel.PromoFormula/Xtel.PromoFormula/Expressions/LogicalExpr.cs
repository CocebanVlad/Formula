using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class LogicalExpr : Expr, IHasAAndB, ICanBeUsedAsBool, ICanBeNegated, IMathExprSuperior
    {
        public LogicalOperatorToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override Enums.Type ReturnType => Enums.Type.Bool;

        public LogicalExpr(IEnv env)
            : base(env)
        {
        }

        private bool EvalLogic()
        {
            if (!(A.Eval() is bool a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Bool));
            }

            if (!(B.Eval() is bool b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Bool));
            }

            switch (Token.Operator)
            {
                case LogicalOperator.And:
                    return a && b;
                case LogicalOperator.Or:
                    return a || b;
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.unknown_operator__0, Token));
        }

        public object Negate() => Helpers.Negate(this);

        public bool GetAsBool() => EvalLogic();

        public override object Eval() => EvalLogic();

        public override string GetAsString() => Helpers.ToString(Eval());

        public override string ToString() => $"{A} {Token} {B}";
    }
}
