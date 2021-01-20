using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class ArithmeticSymbolParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out Token token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if ("+-*/%".IndexOf(str[idxS]) != -1)
                {
                    idxE++;
                    token = new ArithmeticSymbolToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        Operation = Helpers.GetArithmeticOperation(str[idxS]),
                    };

                    return true;
                }
            }

            return false;
        }
    }
}
