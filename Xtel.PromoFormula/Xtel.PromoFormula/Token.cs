﻿using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Token : IToken
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }
    }
}
