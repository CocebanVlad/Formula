namespace CalculationService.Interfaces
{
    public interface IEnv
    {
        void RegisterFunc(IFunc func);
        IFunc GetFunc(string name);
    }
}
