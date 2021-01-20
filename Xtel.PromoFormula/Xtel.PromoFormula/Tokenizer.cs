using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Tokenizer : ITokenizer
    {
        public abstract IList<IToken> Tokenize(in string str);
    }
}
