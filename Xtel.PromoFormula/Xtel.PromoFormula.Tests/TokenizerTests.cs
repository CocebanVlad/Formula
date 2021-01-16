using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Tokenizers;

namespace Xtel.PromoFormula.Tests
{
    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void Test()
        {
            var formula = "( SOURCE(\"GSV_ACT\") * SOURCE(\"NREG_DISC_PERC\",1) / 100.333 + 1e-1 - 9.900001e+1000 - true ) + SOURCE(\"NREG_DISC_CU\") * SOURCE(\"VOL_ACT_2\") ";
            var tokenizer = new FormulaTokenizer();
            var tokens = tokenizer.Tokenize(formula);
            var bldr = new StringBuilder();
            foreach (var token in tokens)
            {
                bldr.Append(token.ToString());
            }
            formula = bldr.ToString();
        }
    }
}
