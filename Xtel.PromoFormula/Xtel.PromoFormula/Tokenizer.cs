﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class Tokenizer
    {
        public abstract IList<Token> Tokenize(string str);
    }
}
