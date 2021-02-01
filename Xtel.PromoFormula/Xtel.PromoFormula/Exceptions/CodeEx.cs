namespace CalculationService.Exceptions
{
    public class CodeEx : Ex
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }

        public CodeEx(int idxS, int idxE, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public CodeEx(int idxS, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }
    }
}
