using System.Collections.Generic;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
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

                throw new ParseEx(idx, $"Unexpected char at: {idx}");
            }

            return tokens;
        }
    }
}
