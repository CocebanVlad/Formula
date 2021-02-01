using CalculationService.Interfaces;

namespace CalculationService
{
    public abstract class Token : IToken
    {
        public int IdxS { get; set; }
        public int IdxE { get; set; }
    }
}
