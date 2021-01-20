using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.Enums;

namespace Xtel.PromoFormula
{
    public static class Helpers
    {
        public static void ConsumeChars(in string str, in string chars, ref int idx)
        {
            if (chars.Length == 0)
            {
                return;
            }

            if (chars.IndexOf(str[idx]) == -1)
            {
                return;
            }

            for (; idx < str.Length; idx++)
            {
                if (chars.IndexOf(str[idx]) == -1)
                {
                    break;
                }
            }
        }

        public static bool ConsumeWord(in string str, in string word, ref int idx)
        {
            if (word.Length == 0 || str.Length < word.Length)
            {
                return false;
            }

            for (var i = 0; i < word.Length; i++)
            {
                if (str[idx + i] != word[i])
                {
                    return false;
                }
            }

            idx += word.Length;

            return true;
        }

        public static byte GetNumericValue(in char c)
        {
            switch (c)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case '0':
                    return 0;
            }

            throw new Exception($"{c} not a digit");
        }

        public static ArithmeticOperation GetArithmeticOperation(char c)
        {
            switch (c)
            {
                case '+':
                    return ArithmeticOperation.Add;
                case '-':
                    return ArithmeticOperation.Subtract;
                case '*':
                    return ArithmeticOperation.Multiply;
                case '/':
                    return ArithmeticOperation.Divide;
                case '%':
                    return ArithmeticOperation.Mod;
            }

            throw new Exception($"{c} not an arithmetic symbol");
        }
    }
}
