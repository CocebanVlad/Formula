﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IConstantToken : IToken
    {
        string ConstValueType { get; }
        object ConstValue { get; }
    }
}