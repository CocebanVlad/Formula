using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class SeparatorParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (str[idxS] == ',')
                {
                    idxE++;
                    token = new SeparatorToken() { IdxS = idxS, IdxE = idxE, Symbol = str[idxS], };
                    return true;
                }
            }

            return false;
        }
    }
}
