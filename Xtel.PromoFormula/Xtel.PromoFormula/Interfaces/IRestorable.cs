namespace CalculationService.Interfaces
{
    public interface IRestorable<T>
    {
        T CreateCopy();
        void RestoreFrom(T copy);
    }
}
