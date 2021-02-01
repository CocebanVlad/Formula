namespace CalculationService.Exceptions
{
    public class CodeParseEx : CodeEx
    {
        public CodeParseEx(int idxS, string msg)
            : base(idxS, msg)
        {
        }

        public CodeParseEx(int idxS, int idxE, string msg)
            : base(idxS, idxE, msg)
        {
        }
    }
}
