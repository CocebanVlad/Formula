using System.Collections.Generic;

namespace Xtel.PromoFormula.Interfaces
{
    public interface IFunc
    {
        string Name { get; }
        Enums.Type ReturnType { get; }

        void ValidateArgs(IEnv env, IList<IExpr> args);
        object Exec(IEnv env, IList<IExpr> args);
    }
}
