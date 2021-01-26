﻿using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
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
                if (Helpers.ConsumeWord(str, Constants.BoolTrueValue, ref idxE))
                {
                    token = new BoolToken() { IdxS = idxS, IdxE = idxE, Value = true, };
                    return true;
                }
                #endregion

                #region False
                if (Helpers.ConsumeWord(str, Constants.BoolFalseValue, ref idxE))
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
