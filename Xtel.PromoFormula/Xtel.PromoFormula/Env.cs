using CalculationService.Interfaces;
using System.Collections.Generic;

namespace CalculationService
{
    public abstract class Env : IEnv
    {
        public abstract IDictionary<string, IFunc> Functions { get; }

        public void RegisterFunc(IFunc func) => Functions.Add(func.Name, func);

        public IFunc GetFunc(string name) => Functions.ContainsKey(name) ? Functions[name] : null;
    }
}
