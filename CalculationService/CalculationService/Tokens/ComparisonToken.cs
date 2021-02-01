using CalculationService.Enums;
using CalculationService.Exceptions;

namespace CalculationService.Tokens
{
    public class ComparisonToken : Token
    {
        public ComparisonOperator Operator { get; set; }

        public override string ToString()
        {
            switch (Operator)
            {
                case ComparisonOperator.Equal:
                    return "==";
                case ComparisonOperator.NotEqual:
                    return "!=";
                case ComparisonOperator.GreaterThanOrEqual:
                    return ">=";
                case ComparisonOperator.GreaterThan:
                    return ">";
                case ComparisonOperator.LessThanOrEqual:
                    return "<=";
                case ComparisonOperator.LessThan:
                    return "<";
            }

            throw new Ex(string.Format(
                tr.unknown_operator__0,
                Operator
                ));
        }
    }
}
