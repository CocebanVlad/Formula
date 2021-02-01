using System;
using System.Collections.Generic;

namespace CalculationService.Interfaces
{
    public interface IFuncBuilder
    {
    }

    #region Name defining step
    public interface IFuncBuilder_NameDefiningStep : IFuncBuilder
    {
        IFuncBuilder_ArgDefiningStep WithName(string name);
    }
    #endregion

    #region Argument defining step
    public interface IFuncBuilder_ArgDefiningStep : IFuncBuilder, IFuncBuilder_ReturnTypeDefiningStep
    {
        IFuncBuilder_ArgDefiningStep WithArg(Enums.Type type);
        IFuncBuilder_ReturnTypeDefiningStep WithExtraArgsValidation(Action<IEnv, IList<IExpr>> action);
    }
    #endregion

    #region Return type defining step
    public interface IFuncBuilder_ReturnTypeDefiningStep : IFuncBuilder
    {
        IFuncBuilder_ImplDefiningStep<object> ReturnAny();
        IFuncBuilder_ImplDefiningStep<object[]> ReturnArray();
        IFuncBuilder_ImplDefiningStep<bool> ReturnBool();
        IFuncBuilder_ImplDefiningStep<bool[]> ReturnBoolArray();
        IFuncBuilder_ImplDefiningStep<double> ReturnNumber();
        IFuncBuilder_ImplDefiningStep<double[]> ReturnNumberArray();
        IFuncBuilder_ImplDefiningStep<string> ReturnString();
        IFuncBuilder_ImplDefiningStep<string[]> ReturnStringArray();
    }
    #endregion

    #region Implementation defining step
    public interface IFuncBuilder_ImplDefiningStep<TResult> : IFuncBuilder
    {
        IFunc WithImpl(Func<IEnv, IList<IExpr>, TResult> impl);
    }
    #endregion
}
