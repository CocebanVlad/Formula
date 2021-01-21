using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Exceptions;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokens;

namespace Xtel.PromoFormula.Parsers
{
    public class NumberParser : Parser
    {
        public override bool TryParse(in string str, int idxS, out int idxE, out IToken token)
        {
            idxE = idxS;
            token = null;

            if (idxS < str.Length)
            {
                var head = 0; // 0 - whole part; 1 - fractional part; 2 - exponent;
                var number = new StringBuilder();

                if (str[idxS] == '+' || str[idxS] == '-')
                {
                    if (idxS > 0)
                    {
                        var tempIdxS = idxS - 1;
                        Helpers.ConsumeWhitespace(str, ref tempIdxS, ParsingDirection.Left);
                        if (",(".IndexOf(str[tempIdxS]) == -1)
                        {
                            return false;
                        }
                    }

                    number.Append(str[idxS]);
                    idxE++;
                }

                if (char.IsDigit(str[idxE]))
                {
                    for (; idxE < str.Length; idxE++)
                    {
                        if (char.IsDigit(str[idxE]))
                        {
                            number.Append(str[idxE]);
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
                                throw new ParseEx(idxE, $"Unexpected char at: {idxE}");
                            }

                            head = 1;
                            number.Append('.');
                            continue;
                        }

                        if ("eE".IndexOf(str[idxE]) > -1)
                        {
                            if (head == 2)
                            {
                                throw new ParseEx(idxE, $"Unexpected char at: {idxE}");
                            }

                            head = 2;
                            number.Append('E');

                            if (str.Length > idxE + 1 && (str[idxE + 1] == '+' || str[idxE + 1] == '-'))
                            {
                                idxE++;
                                number.Append(str[idxE]);
                            }

                            continue;
                        }

                        break;
                    }

                    if ("_eE".IndexOf(str[idxE - 1]) > -1)
                    {
                        throw new ParseEx(idxE - 1, $"Unexpected char at: {idxE - 1}");
                    }

                    var numStr =
                        number.ToString();
                    var numInfo = new NumberFormatInfo()
                    {
                        PositiveSign = "+",
                        NegativeSign = "-",
                        NumberDecimalSeparator = ".",
                    };
                    if (!double.TryParse(numStr, NumberStyles.Any, numInfo, out double num))
                    {
                        throw new ParseEx(idxS, idxE, $"Invalid numeric literal: '{numStr}' starting at: {idxS}");
                    }

                    token = new NumberToken() { IdxS = idxS, IdxE = idxE, Number = num, };
                    return true;
                }
            }

            return false;
        }
    }
}