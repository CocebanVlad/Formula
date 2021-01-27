using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xtel.PromoFormula.Enums;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public static class Helpers
    {
        public static void ConsumeChars(
            in string str,
            in string chars,
            ref int idx,
            ParsingDirection dir = ParsingDirection.Right)
        {
            if (idx < 0)
            {
                return;
            }

            if (chars.Length == 0)
            {
                return;
            }

            if (chars.IndexOf(str[idx]) == -1)
            {
                return;
            }

            switch (dir)
            {
                case ParsingDirection.Right:

                    for (; idx < str.Length; idx++)
                    {
                        if (chars.IndexOf(str[idx]) == -1)
                        {
                            break;
                        }
                    }

                    break;
                case ParsingDirection.Left:

                    for (; idx >= 0; idx--)
                    {
                        if (chars.IndexOf(str[idx]) == -1)
                        {
                            break;
                        }
                    }

                    break;
            }
        }

        public static bool ConsumeWord(
            in string str,
            in string word,
            ref int idx,
            ParsingDirection dir = ParsingDirection.Right)
        {
            if (idx < 0)
            {
                return false;
            }

            if (word.Length == 0 || str.Length < word.Length)
            {
                return false;
            }

            switch (dir)
            {
                case ParsingDirection.Right:

                    for (var i = 0; i < word.Length; i++)
                    {
                        if (str[idx + i] != word[i])
                        {
                            return false;
                        }
                    }

                    idx += word.Length;

                    break;

                case ParsingDirection.Left:

                    for (var i = word.Length - 1; i >= 0; i--)
                    {
                        if (str[idx - i] != word[i])
                        {
                            return false;
                        }
                    }

                    idx -= word.Length;

                    break;
            }

            return true;
        }

        public static void ConsumeWhitespace(
            in string str,
            ref int idx,
            ParsingDirection dir = ParsingDirection.Right)
        {
            ConsumeChars(str, " \b\f\n\r\t\v", ref idx, dir);
        }

        public static byte GetNumericValue(in char c)
        {
            switch (c)
            {
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case '0': return 0;
            }

            throw new Exception(
                string.Format(tr._0__not_a_digit, c));
        }

        public static ArithmeticOperation GetArithmeticOperation(char c)
        {
            switch (c)
            {
                case '+': return ArithmeticOperation.Add;
                case '-': return ArithmeticOperation.Subtract;
                case '*': return ArithmeticOperation.Multiply;
                case '/': return ArithmeticOperation.Divide;
                case '%': return ArithmeticOperation.Mod;
            }

            throw new Exception(
                string.Format(tr._0__not_an_arithmetic_symbol, c));
        }

        public static int GetArithmeticOperationPriority(ArithmeticOperation op)
        {
            switch (op)
            {
                case ArithmeticOperation.Add:
                    return 0;
                case ArithmeticOperation.Subtract:
                    return 0;
                case ArithmeticOperation.Multiply:
                    return 1;
                case ArithmeticOperation.Divide:
                    return 1;
                case ArithmeticOperation.Mod:
                    return 1;
            }

            return -1;
        }

        public static IFormatProvider GetNumberFormatProvider() =>
            new NumberFormatInfo() { PositiveSign = "+", NegativeSign = "-", NumberDecimalSeparator = ".", };

        public static string ToString(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (obj is bool b)
            {
                return b ? "true" : "false";
            }
            if (obj is double num)
            {
                return num.ToString(GetNumberFormatProvider());
            }
            if (obj is string str)
            {
                return str;
            }
            if (obj is Array arr)
            {
                return string.Join(",", arr);
            }

            throw new Exception(
                string.Format(
                    tr.cannot_transform__0__into_a_string,
                    obj.GetType().FullName
                    ));
        }

        public static bool ArgsMatchFuncSignature(IList<IExpr> args, IList<Enums.Type> signature)
        {
            if (args.Count != signature.Count)
            {
                return false;
            }

            for (var idx = 0; idx < args.Count; idx++)
            {
                if (signature[idx] == Enums.Type.Any)
                {
                    continue;
                }

                if (args[idx].ReturnType != signature[idx])
                {
                    return false;
                }
            }

            return true;
        }

        public static Enums.Type GetArrayType(IList<IExpr> elements)
        {
            var types = elements.Select(el => el.ReturnType).Distinct();
            if (types.Count() == 1)
            {
                switch (types.First())
                {
                    case Enums.Type.Bool:
                        return Enums.Type.BoolArray;
                    case Enums.Type.Number:
                        return Enums.Type.NumberArray;
                    case Enums.Type.String:
                        return Enums.Type.StringArray;
                }
            }

            return Enums.Type.Array;
        }

        public static object ToArray(IEnumerable<object> elements, Enums.Type type)
        {
            switch (type)
            {
                case Enums.Type.BoolArray:
                    return elements.Cast<bool>().ToArray();
                case Enums.Type.NumberArray:
                    return elements.Cast<double>().ToArray();
                case Enums.Type.StringArray:
                    return elements.Cast<string>().ToArray();
            }

            return elements;
        }
    }
}
