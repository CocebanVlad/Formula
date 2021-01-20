using System;
using System.Collections.Generic;
using System.Text;

namespace Xtel.PromoFormula
{
    public abstract class TypedFn<TValue> : Fn where TValue : struct
    {
        public abstract TValue ExecWithAnExpectedType(object[] args);

        public override object Exec(object[] args) => ExecWithAnExpectedType(args);
    }
}
