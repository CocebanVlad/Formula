using CalculationService.Interfaces;

namespace CalculationService
{
    public abstract class Parser : IParser
    {
        public abstract bool TryParse(in string str, int idxS, out int idxE, out IToken token);
    }
}
