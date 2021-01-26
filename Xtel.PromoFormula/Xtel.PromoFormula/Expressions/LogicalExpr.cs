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
        public override string ReturnType => Constants.BoolType;

        private bool EvalLogicalOperator(IEvalEnv env)
        {
            if (!(A.Eval(env) is bool a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.BoolType));
            }

            if (!(B.Eval(env) is bool b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.BoolType));
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

        public object Negate(IEvalEnv env) => !EvalLogicalOperator(env);

        public bool GetAsBool(IEvalEnv env) => EvalLogicalOperator(env);

        public override object Eval(IEvalEnv env) => EvalLogicalOperator(env);

        public override string GetAsString(IEvalEnv env) => Helpers.ToString(Eval(env));

        public override string ToString() => $"{A} {Token} {B}";
    }
}
