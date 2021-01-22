using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Parser : IParser
    {
        public abstract bool TryParse(in string str, int idxS, out int idxE, out IToken token);
    }
}
