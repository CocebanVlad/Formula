using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class ComparisonParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                #region Equal
                if (Helpers.ConsumeWord(str, "===", ref idxE) || Helpers.ConsumeWord(str, "==", ref idxE))
                {
                    token = new ComparisonToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = Enums.ComparisonOperator.Equal,
                    };

                    return true;
                }
                #endregion

                #region Not equal
                if (Helpers.ConsumeWord(str, "!==", ref idxE) || Helpers.ConsumeWord(str, "!=", ref idxE))
                {
                    token = new ComparisonToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = Enums.ComparisonOperator.NotEqual,
                    };

                    return true;
                }
                #endregion

                #region Greater than or equal
                if (Helpers.ConsumeWord(str, ">=", ref idxE))
                {
                    token = new ComparisonToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = Enums.ComparisonOperator.GreaterThanOrEqual,
                    };

                    return true;
                }
                #endregion

                #region Greater than
                if (Helpers.ConsumeWord(str, ">", ref idxE))
                {
                    token = new ComparisonToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = Enums.ComparisonOperator.GreaterThan,
                    };

                    return true;
                }
                #endregion

                #region Less than or equal
                if (Helpers.ConsumeWord(str, "<=", ref idxE))
                {
                    token = new ComparisonToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = Enums.ComparisonOperator.LessThanOrEqual,
                    };

                    return true;
                }
                #endregion

                #region Less than
                if (Helpers.ConsumeWord(str, "<", ref idxE))
                {
                    token = new ComparisonToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = Enums.ComparisonOperator.LessThan,
                    };

                    return true;
                }
                #endregion
            }

            return false;
        }
    }
}
