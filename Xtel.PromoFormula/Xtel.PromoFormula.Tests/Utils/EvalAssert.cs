using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.Tests.Utils
{
    public static class EvalAssert
    {
        public static void IsExpectedEvalResult<TValue>(
            ITokenizer tokenizer,
            IBuildingPipeline pipeline,
            in string formula,
            TValue expectedResult)
        {
            var exprs = pipeline.Build(tokenizer.Tokenize(formula));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(expectedResult, (TValue)exprs.First().Eval());
        }
    }
}
