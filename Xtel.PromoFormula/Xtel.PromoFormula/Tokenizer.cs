using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class Tokenizer
    {
        public abstract ICollection<Token> Tokenize(string str);
    }
}
