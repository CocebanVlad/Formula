using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class ParenthesisParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out Token token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (str[idxS] == '(')
                {
                    idxE++;
                    token = new ParenthesisToken() { IdxS = idxS, IdxE = idxE, IsOpen = true, };
                    return true;
                }

                if (str[idxS] == ')')
                {
                    idxE++;
                    token = new ParenthesisToken() { IdxS = idxS, IdxE = idxE, IsOpen = false, };
                    return true;
                }
            }

            return false;
        }
    }
}
