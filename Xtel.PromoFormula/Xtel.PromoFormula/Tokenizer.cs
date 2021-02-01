using CalculationService.Exceptions;
using CalculationService.Interfaces;
using System.Collections.Generic;

namespace CalculationService
{
    public abstract class Tokenizer : ITokenizer
    {
        protected abstract IList<IParser> Parsers { get; }

        public virtual IList<IToken> Tokenize(in string str)
        {
            var tokens = new List<IToken>();
            var idx = 0;

            while (idx < str.Length)
            {
                Helpers.ConsumeWhitespace(str, ref idx);

                var parsed = false;

                foreach (var parser in Parsers)
                {
                    if (parser.TryParse(str, idx, out idx, out IToken token))
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

                throw new CodeParseEx(idx,
                    string.Format(tr.unexpected_char_at__0, idx));
            }

            return tokens;
        }
    }
}
