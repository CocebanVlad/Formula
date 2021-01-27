﻿namespace Xtel.PromoFormula.Interfaces
{
    public interface IConstantToken : IToken
    {
        Enums.Type ConstValueType { get; }
        object ConstValue { get; }
        string ConstValueAsString { get; }
    }
}
