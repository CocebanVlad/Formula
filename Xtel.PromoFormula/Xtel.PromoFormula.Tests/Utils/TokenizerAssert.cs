using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Tests.Utils
{
    public static class TokenizerAssert
    {
        public static void AssertToken<TToken>(Token token, Action<TToken> action) where TToken : Token
        {
            Assert.IsInstanceOfType(token, typeof(TToken));
            action.Invoke((TToken)token);
        }
    }
}
