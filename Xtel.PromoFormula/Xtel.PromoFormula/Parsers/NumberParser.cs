using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class NumberParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out Token token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                if (char.IsNumber(str[idxS]))
                {
                    uint[] parts = { 0, 0, 0 }; // 0 - whole part; 1 - fractional part; 2 - exponent;
                    byte head = 0;
                    bool hasNegativeExponent = false;

                    for (; idxE < str.Length; idxE++)
                    {
                        if (char.IsDigit(str[idxE]))
                        {
                            parts[head] *= 10;
                            parts[head] += Helpers.GetNumericValue(str[idxE]);
                            continue;
                        }

                        if (str[idxE] == '_')
                        {
                            continue;
                        }

                        if (str[idxE] == '.')
                        {
                            if (head != 0)
                            {
                                throw new ParsingException(idxE, $"Unexpected char at: {idxE}");
                            }

                            head = 1;
                            continue;
                        }

                        if (str[idxE] == 'e' || str[idxE] == 'E')
                        {
                            if (head == 2)
                            {
                                throw new ParsingException(idxE, $"Unexpected char at: {idxE}");
                            }

                            head = 2;
                            idxE++;

                            if (str[idxE] != '+' && str[idxE] != '-')
                            {
                                throw new ParsingException(idxE, $"Unexpected char at: {idxE}");
                            }

                            hasNegativeExponent = str[idxE] == '-';
                            continue;
                        }

                        if (head == 2 && parts[2] == 0)
                        {
                            throw new ParsingException(idxE, $"Unexpected char at: {idxE}");
                        }

                        break;
                    }

                    var num = new NumberInfo()
                    {
                        WholePart = parts[0],
                        FractionalPart = parts[1],
                        Exponent = parts[2],
                        HasNegativeExponent = hasNegativeExponent,
                    };

                    token = new NumberToken() { IdxS = idxS, IdxE = idxE, Number = num, };
                    return true;
                }
            }

            return false;
        }

        public override void ValidateOccurrence(ICollection<Token> tokens)
        {
        }
    }
}