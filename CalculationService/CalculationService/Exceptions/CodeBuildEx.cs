namespace CalculationService.Exceptions
{
    public class CodeBuildEx : CodeEx
    {
        public CodeBuildEx(int idxS, string msg)
            : base(idxS, msg)
        {
        }

        public CodeBuildEx(int idxS, int idxE, string msg)
            : base(idxS, idxE, msg)
        {
        }
    }
}
