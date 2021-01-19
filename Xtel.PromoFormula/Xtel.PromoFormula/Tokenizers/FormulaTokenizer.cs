using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Parsers;

namespace Xtel.PromoFormula.Tokenizers
{
    public class FormulaTokenizer : Tokenizer
    {
        private ICollection<Parser> _parsers = new HashSet<Parser>();

        public FormulaTokenizer()
        {
            _parsers.Add(new StringParser());
            _parsers.Add(new BoolParser());
            _parsers.Add(new NumberParser());
            _parsers.Add(new LogicalOperatorParser());
            _parsers.Add(new ComparisonParser());
            _parsers.Add(new NegationParser());
            _parsers.Add(new ArithmeticSymbolParser());
            _parsers.Add(new SeparatorParser());
            _parsers.Add(new ParenthesisParser());
            _parsers.Add(new LiteralParser());
        }

        public override ICollection<Token> Tokenize(string str)
        {
            var tokens = new HashSet<Token>();
            var idx = 0;

            while (idx < str.Length)
            {
                Helpers.ConsumeChars(str, " \b\f\n\r\t\v", ref idx);

                var parsed = false;

                foreach (var parser in _parsers)
                {
                    if (parser.TryParse(str, idx, out idx, out Token token))
                    {
                        parsed = true;
                        tokens.Add(token);
                        break;
                    }
                }

                if (parsed)
                {
                    continue;
                }

                if (idx >= str.Length)
                {
                    break;
                }

                throw new ParsingException(idx, $"Unexpected char at: {idx}");
            }

            return tokens;
        }
    }
}
