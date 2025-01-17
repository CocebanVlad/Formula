﻿using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Parsers
{
    public class LiteralParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (str[idxS] == '_' || char.IsLetter(str[idxS]))
                {
                    idxE++;

                    for (; idxE < str.Length; idxE++)
                    {
                        if (str[idxE] == '_' || char.IsLetterOrDigit(str[idxE]))
                        {
                            continue;
                        }

                        break;
                    }

                    token = new LiteralToken()
                    {
                        IdxS = idxS,
                        IdxE = idxE,
                        String = str.Substring(idxS, idxE - idxS),
                    };

                    return true;
                }
            }

            return false;
        }
    }
}
