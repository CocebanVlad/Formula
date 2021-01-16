using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class Parser
    {
        public abstract bool TryParse(in string str, int idxS, out int idxE, out Token token);

        public abstract void ValidateOccurrence(ICollection<Token> tokens);
    }
}
