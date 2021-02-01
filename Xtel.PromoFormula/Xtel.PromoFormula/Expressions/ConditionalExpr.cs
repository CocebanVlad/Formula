using CalculationService.Enums;
using CalculationService.Exceptions;
using CalculationService.Interfaces;
using CalculationService.Tokens;
using System.Linq;

namespace CalculationService.Expressions
{
    public class ConditionalExpr : Expr, IHasAAndB, ICanBeUsedAsBool, ICanBeNegated, IMathExprSuperior
    {
        public ComparisonToken Token { get; set; }
        public IExpr A { get; set; }
        public IExpr B { get; set; }

        public override int IdxS => A.IdxS;
        public override int IdxE => B.IdxE;
        public override Enums.Type ReturnType => Enums.Type.Bool;

        public ConditionalExpr(IEnv env)
            : base(env)
        {
        }

        private bool EvalCondition()
        {
            if (A.ReturnType == Enums.Type.Any || B.ReturnType == Enums.Type.Any)
            {
                return PerformComparisonAsForAny();
            }

            if (A.ReturnType != B.ReturnType)
            {
                throw new RuntimeEx(IdxS, IdxE, tr.a_and_b_must_be_of_a_same_type);
            }

            switch (A.ReturnType)
            {
                case Enums.Type.Bool:
                    return PerformComparisonAsForBools();
                case Enums.Type.Number:
                    return PerformComparisonAsForNumbers();
                case Enums.Type.String:
                    return PerformComparisonAsForStrings();
            }

            throw new RuntimeEx(IdxS, IdxE,
                string.Format(tr.cant_compare_objects_of__0__type,
                    A.ReturnType
                    ));
        }

        private bool PerformComparisonAsForAny()
        {
            var a = A.Eval();
            var b = B.Eval();

            if (a.GetType() != b.GetType())
            {
                throw new RuntimeEx(IdxS, IdxE, tr.a_and_b_must_be_of_a_same_type);
            }

            if (a is bool)
            {
                return PerformComparisonAsForBools();
            }
            if (a is double)
            {
                return PerformComparisonAsForNumbers();
            }
            if (a is string)
            {
                return PerformComparisonAsForStrings();
            }

            switch (Token.Operator)
            {
                case ComparisonOperator.Equal:
                    return a == b;
                case ComparisonOperator.NotEqual:
                    return a != b;
            }

            throw new CodeBuildEx(IdxS, IdxE,
                string.Format(tr.operator__0__cannot_be_applied_to_operands_of_type_any_whenever_those_cannot_be_evaluated_as__1,
                    Token.Operator,
                    string.Join(", ", System.Enum.GetNames(typeof(Enums.Type)).Select(t => $"'{t}'"))
                    ));
        }

        private bool PerformComparisonAsForBools()
        {
            if (!(A.Eval() is bool a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Bool));
            }

            if (!(B.Eval() is bool b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "B", Enums.Type.Bool));
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
                    Enums.Type.Bool
                    ));
        }

        private bool PerformComparisonAsForNumbers()
        {
            if (!(A.Eval() is double a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.Number));
            }

            if (!(B.Eval() is double b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "B", Enums.Type.Number));
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
                    Enums.Type.Number
                    ));
        }

        private bool PerformComparisonAsForStrings()
        {
            if (!(A.Eval() is string a))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "A", Enums.Type.String));
            }

            if (!(B.Eval() is string b))
            {
                throw new RuntimeEx(A.IdxS, A.IdxE,
                    string.Format(tr._0__is_not__1__type, "B", Enums.Type.String));
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
                    Enums.Type.String
                    ));
        }

        public object Negate() => !EvalCondition();

        public bool GetAsBool() => EvalCondition();

        public override object Eval() => EvalCondition();

        public override string GetAsString() => Helpers.ToString(EvalCondition());

        public override string ToString() => $"{A} {Token} {B}";
    }
}
