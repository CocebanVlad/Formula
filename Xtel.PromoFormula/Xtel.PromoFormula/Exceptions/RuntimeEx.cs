namespace Xtel.PromoFormula.Exceptions
{
    public class RuntimeEx : Ex
    {
        public RuntimeEx(int idxS)
            : base(idxS)
        {
        }

        public RuntimeEx(int idxS, int idxE)
            : base(idxS, idxE)
        {
        }

        public RuntimeEx(int idxS, string msg)
            : base(idxS, msg)
        {
        }

        public RuntimeEx(int idxS, int idxE, string msg)
            : base(idxS, idxE, msg)
        {
        }
    }
}
