﻿using CalculationService.Enums;
using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Parsers
{
    public class LogicalOperatorParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                #region And
                if (Helpers.ConsumeWord(str, "&&", ref idxE))
                {
                    token = new LogicalOperatorToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = LogicalOperator.And,
                    };

                    return true;
                }
                #endregion

                #region Or
                if (Helpers.ConsumeWord(str, "||", ref idxE))
                {
                    token = new LogicalOperatorToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operator = LogicalOperator.Or,
                    };

                    return true;
                }
                #endregion
            }

            return false;
        }
    }
}
