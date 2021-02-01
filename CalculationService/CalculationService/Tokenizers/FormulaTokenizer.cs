using CalculationService.Interfaces;
using CalculationService.Parsers;
using System.Collections.Generic;

namespace CalculationService.Tokenizers
{
    public class FormulaTokenizer : Tokenizer
    {
        protected override IList<IParser> Parsers { get; }
            = new List<IParser>();

        public FormulaTokenizer()
        {
            Parsers.Add(new StringParser());
            Parsers.Add(new BoolParser());
            Parsers.Add(new NumberParser());
            Parsers.Add(new LogicalOperatorParser());
            Parsers.Add(new ComparisonParser());
            Parsers.Add(new NegationParser());
            Parsers.Add(new ArithmeticSymbolParser());
            Parsers.Add(new SeparatorParser());
            Parsers.Add(new ArrayParenthesisParser());
            Parsers.Add(new ParenthesisParser());
            Parsers.Add(new LiteralParser());
        }
    }
}
