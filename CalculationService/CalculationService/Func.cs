using CalculationService.Interfaces;
using System.Collections.Generic;

namespace CalculationService
{
    public abstract class Func : IFunc
    {
        public abstract string Name { get; }
        public abstract Enums.Type ReturnType { get; }

        public abstract void ValidateArgs(IEnv env, IList<IExpr> args);
        public abstract object Exec(IEnv env, IList<IExpr> args);
    }
}
