namespace Xtel.PromoFormula.Exceptions
{
    public class ParseEx : Ex
    {
        public ParseEx(int idxS)
            : base(idxS)
        {
        }

        public ParseEx(int idxS, int idxE)
            : base(idxS, idxE)
        {
        }

        public ParseEx(int idxS, string msg)
            : base(idxS, msg)
        {
        }

        public ParseEx(int idxS, int idxE, string msg)
            : base(idxS, idxE, msg)
        {
        }
    }
}
