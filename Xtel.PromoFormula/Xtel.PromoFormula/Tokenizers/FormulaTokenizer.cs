using System.Collections.Generic;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Parsers;

namespace Xtel.PromoFormula.Tokenizers
{
    public class FormulaTokenizer : Tokenizer
    {
        protected override IList<IParser> Parsers => new List<IParser>()
        {
            new StringParser(),
            new BoolParser(),
            new NumberParser(),
            new LogicalOperatorParser(),
            new ComparisonParser(),
            new NegationParser(),
            new ArithmeticSymbolParser(),
            new SeparatorParser(),
            new ParenthesisParser(),
            new LiteralParser(),
        };
    }
}
