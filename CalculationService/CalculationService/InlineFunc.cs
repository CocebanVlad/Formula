using CalculationService.Interfaces;
using System;
using System.Collections.Generic;

namespace CalculationService
{
    public class InlineFunc : Func
    {
        private readonly string _name;
        private readonly Enums.Type _returnType;
        private readonly Action<IEnv, IList<IExpr>> _argsValidationAction;
        private readonly Func<IEnv, IList<IExpr>, object> _execFunc;

        public override string Name => _name;
        public override Enums.Type ReturnType => _returnType;

        public InlineFunc(
            string name,
            Enums.Type returnType,
            Action<IEnv, IList<IExpr>> argsValidationAction,
            Func<IEnv, IList<IExpr>, object> execFunc)
        {
            _name = name;
            _returnType = returnType;
            _execFunc = execFunc;
            _argsValidationAction = argsValidationAction;
        }

        public override void ValidateArgs(IEnv env, IList<IExpr> args) => _argsValidationAction.Invoke(env, args);

        public override object Exec(IEnv env, IList<IExpr> args) => _execFunc.Invoke(env, args);
    }
}
