using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class ArrayParenthesisParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (str[idxS] == '[')
                {
                    idxE++;
                    token = new ArrayParenthesisToken() { IdxS = idxS, IdxE = idxE, IsOpen = true, };
                    return true;
                }

                if (str[idxS] == ']')
                {
                    idxE++;
                    token = new ArrayParenthesisToken() { IdxS = idxS, IdxE = idxE, IsOpen = false, };
                    return true;
                }
            }

            return false;
        }
    }
}
