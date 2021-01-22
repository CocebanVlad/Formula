using System;
using Xtel.PromoFormula.Enums;

namespace Xtel.PromoFormula.Tokens
{
    public class LogicalOperatorToken : Token
    {
        public LogicalOperator Operator { get; set; }

        public override string ToString()
        {
            switch (Operator)
            {
                case LogicalOperator.And:
                    return "&&";
                case LogicalOperator.Or:
                    return "||";
            }

            throw new Exception(string.Format(
                tr.unknown_operator__0,
                Operator
                ));
        }
    }
}
