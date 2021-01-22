using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class NegationParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (str[idxS] == '!')
                {
                    idxE++;
                    token = new NegationToken() { IdxS = idxS, IdxE = idxE, };
                    return true;
                }
            }

            return false;
        }
    }
}
