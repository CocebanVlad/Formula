namespace CalculationService.Exceptions
{
    public class RuntimeEx : Ex
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }

        public RuntimeEx(int idxS, int idxE, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxE;
        }

        public RuntimeEx(int idxS, string msg)
            : base(msg)
        {
            IdxS = idxS;
            IdxE = idxS + 1;
        }
    }
}
