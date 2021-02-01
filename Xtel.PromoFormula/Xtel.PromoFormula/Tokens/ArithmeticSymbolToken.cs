using CalculationService.Enums;
using CalculationService.Exceptions;

namespace CalculationService.Tokens
{
    public class ArithmeticSymbolToken : Token
    {
        public ArithmeticOperation Operation { get; set; }

        public override string ToString()
        {
            switch (Operation)
            {
                case ArithmeticOperation.Add:
                    return "+";
                case ArithmeticOperation.Subtract:
                    return "-";
                case ArithmeticOperation.Multiply:
                    return "*";
                case ArithmeticOperation.Divide:
                    return "/";
                case ArithmeticOperation.Mod:
                    return "%";
            }

            throw new Ex(string.Format(
                tr.unknown_operation__0,
                Operation
                ));
        }
    }
}
