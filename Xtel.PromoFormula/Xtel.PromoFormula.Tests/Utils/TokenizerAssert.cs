using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tests.Utils
{
    public static class TokenizerAssert
    {
        public static void AssertToken<TToken>(IToken token, Action<TToken> action) where TToken : IToken
        {
            Assert.IsInstanceOfType(token, typeof(TToken));
            action.Invoke((TToken)token);
        }
    }
}
