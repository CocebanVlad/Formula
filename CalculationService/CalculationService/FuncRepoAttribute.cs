using System;

namespace CalculationService
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FuncRepositoryAttribute : Attribute
    {
    }
}
