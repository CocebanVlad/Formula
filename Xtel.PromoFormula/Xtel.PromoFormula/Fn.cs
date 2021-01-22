using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public abstract class Fn : IFn
    {
        public abstract object Exec(object[] args);
    }
}
