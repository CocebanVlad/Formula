using CalculationService.Interfaces;
using CalculationService.Tokens;

namespace CalculationService.Parsers
{
    public class ArithmeticSymbolParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
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
