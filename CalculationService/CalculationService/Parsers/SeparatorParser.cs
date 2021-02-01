using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Parsers
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
