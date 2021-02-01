using CalculationService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculationService.Tests.Utils
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
