﻿using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Parsers
{
    public class BoolParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                #region True
                if (Helpers.ConsumeWord(str, "true", ref idxE))
                {
                    token = new BoolToken() { IdxS = idxS, IdxE = idxE, Value = true, };
                    return true;
                }
                #endregion

                #region False
                if (Helpers.ConsumeWord(str, "false", ref idxE))
                {
                    token = new BoolToken() { IdxS = idxS, IdxE = idxE, Value = false, };
                    return true;
                }
                #endregion
            }

            return false;
        }
    }
}
