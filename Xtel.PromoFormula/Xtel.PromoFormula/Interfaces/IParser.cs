namespace CalculationService.Interfaces
{
    public interface IParser
    {
        bool TryParse(in string str, int idxS, out int idxE, out IToken token);
    }
}
