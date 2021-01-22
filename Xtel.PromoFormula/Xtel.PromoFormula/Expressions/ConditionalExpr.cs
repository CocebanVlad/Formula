using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Expressions
{
    public class ConditionalExpr : Expr, ICanBeNegated
    {
        public ComparisonToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override string ReturnType => Constants.BoolType;

        public override object Eval(IEvalEnv env) => EvalCondition(env);

        public object Negate(IEvalEnv env) => !EvalCondition(env);

        private bool EvalCondition(IEvalEnv env)
        {
            if (A.ReturnType != B.ReturnType)
            {
                throw new RuntimeEx(IdxS, IdxE, tr.a_and_b_must_be_of_a_same_type);
            }

            switch (A.ReturnType)
            {
                case Constants.BoolType:
                    return PerformComparisonAsForBools(env);
                case Constants.NumberType:
                    return PerformComparisonAsForNumbers(env);
                case Constants.StringType:
                    return PerformComparisonAsForStrings(env);
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_compare_objects_of__0__type,
                    A.ReturnType
                    ));
        }

        private bool PerformComparisonAsForBools(IEvalEnv env)
        {
            if (!(A.Eval(env) is bool a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.BoolType));
            }

            if (!(B.Eval(env) is bool b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "B", Constants.BoolType));
            }

            switch (Token.Operator)
            {
                case ComparisonOperator.Equal:
                    return a == b;
                case ComparisonOperator.NotEqual:
                    return a != b;
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    Token,
                    Constants.BoolType
                    ));
        }

        private bool PerformComparisonAsForNumbers(IEvalEnv env)
        {
            if (!(A.Eval(env) is double a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.NumberType));
            }

            if (!(B.Eval(env) is double b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "B", Constants.NumberType));
            }

            switch (Token.Operator)
            {
                case ComparisonOperator.Equal:
                    return a == b;
                case ComparisonOperator.NotEqual:
                    return a != b;
                case ComparisonOperator.GreaterThanOrEqual:
                    return a >= b;
                case ComparisonOperator.GreaterThan:
                    return a > b;
                case ComparisonOperator.LessThanOrEqual:
                    return a <= b;
                case ComparisonOperator.LessThan:
                    return a < b;
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    Token,
                    Constants.NumberType
                    ));
        }

        private bool PerformComparisonAsForStrings(IEvalEnv env)
        {
            if (!(A.Eval(env) is string a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Constants.StringType));
            }

            if (!(B.Eval(env) is string b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "B", Constants.StringType));
            }

            switch (Token.Operator)
            {
                case ComparisonOperator.Equal:
                    return a == b;
                case ComparisonOperator.NotEqual:
                    return a != b;
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_apply__0__on__1,
                    Token,
                    Constants.StringType
                    ));
        }
    }
}
