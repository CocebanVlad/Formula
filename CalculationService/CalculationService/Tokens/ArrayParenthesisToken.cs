﻿namespace CalculationService.Tokens
{
    public class ArrayParenthesisToken : Token
    {
        public bool IsOpen { get; set; }

        public override string ToString() => IsOpen ? "[" : "]";
    }
}
