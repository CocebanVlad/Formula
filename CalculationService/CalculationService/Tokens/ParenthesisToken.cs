﻿namespace CalculationService.Tokens
{
    public class ParenthesisToken : Token
    {
        public bool IsOpen { get; set; }

        public override string ToString() => IsOpen ? "(" : ")";
    }
}
