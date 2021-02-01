using CalculationService.Exceptions;
using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Parsers
{
    public class StringParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (str[idxS] == '\"' || str[idxS] == '\'')
                {
                    idxE++;
                    for (; idxE < str.Length; idxE++)
                    {
                        if (str[idxE] == str[idxS] && str[idxE - 1] != '\\')
                        {
                            idxE++;
                            token = new StringToken()
                            {
                                IdxS = idxS,
                                IdxE = idxE,
                                String = str.Substring(idxS + 1, idxE - idxS - 2),
                                NotationChar = str[idxS],
                            };

                            return true;
                        }
                    }

                    throw new CodeParseEx(idxE,
                        string.Format(tr.unexpected_char_at__0, idxE));
                }
            }

            return false;
        }
    }
}
