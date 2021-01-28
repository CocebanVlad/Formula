using System;
using System.Collections.Generic;
using System.Linq;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula
{
    public partial class FuncBuilder :
        IFuncBuilder,
        IFuncBuilder_NameDefiningStep,
        IFuncBuilder_ArgDefiningStep,
        IFuncBuilder_ReturnTypeDefiningStep
    {
        private string _name;
        private Enums.Type _returnType;
        private readonly IFuncArgsSignature _argsSig
            = new FuncArgsSignature();

        private Action<IEnv, IList<IExpr>> _extraArgsValidationAction = null;

        private FuncBuilder()
        {
        }

        public static IFuncBuilder_NameDefiningStep Create() => new FuncBuilder();

        private Action<IEnv, IList<IExpr>> BuildArgsValidationAction() => (env, args) =>
        {
            if (!Helpers.ArgsMatchFuncArgsSignature(args, _argsSig))
            {
                var expectedSigStr =
                    Helpers.ToFuncSig(_name, _returnType, _argsSig);

                var providedSigStr =
                    Helpers.ToFuncSig(_name, _returnType, args.Select(arg => arg.ReturnType).ToList());

                throw new Exception(
                    string.Format(tr.the_arguments_provided_do_not_match_the_signature__expected__0__provided__1,
                        expectedSigStr,
                        providedSigStr
                        ));
            }

            if (_extraArgsValidationAction != null)
            {
                _extraArgsValidationAction.Invoke(env, args);
            }
        };

        #region Name defining step
        public IFuncBuilder_ArgDefiningStep WithName(string name)
        {
            _name = name;
            return this;
        }
        #endregion

        #region Argument defining step
        public IFuncBuilder_ArgDefiningStep WithArg(Enums.Type type)
        {
            _argsSig.Add(type);
            return this;
        }

        public IFuncBuilder_ReturnTypeDefiningStep WithExtraArgsValidation(Action<IEnv, IList<IExpr>> action)
        {
            _extraArgsValidationAction = action;
            return this;
        }
        #endregion

        #region Return type defining step
        public IFuncBuilder_ImplDefiningStep<object> ReturnAny()
        {
            _returnType = Enums.Type.Any;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<object[]> ReturnArray()
        {
            _returnType = Enums.Type.Array;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<bool> ReturnBool()
        {
            _returnType = Enums.Type.Bool;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<bool[]> ReturnBoolArray()
        {
            _returnType = Enums.Type.BoolArray;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<double> ReturnNumber()
        {
            _returnType = Enums.Type.Number;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<double[]> ReturnNumberArray()
        {
            _returnType = Enums.Type.NumberArray;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<string> ReturnString()
        {
            _returnType = Enums.Type.String;
            return this;
        }

        public IFuncBuilder_ImplDefiningStep<string[]> ReturnStringArray()
        {
            _returnType = Enums.Type.StringArray;
            return this;
        }
        #endregion
    }

    #region Any
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<object>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, object> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region Array
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<object[]>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, object[]> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region Bool
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<bool>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, bool> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region BoolArray
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<bool[]>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, bool[]> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region Number
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<double>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, double> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region NumberArray
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<double[]>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, double[]> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region String
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<string>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, string> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion

    #region StringArray
    public partial class FuncBuilder : IFuncBuilder_ImplDefiningStep<string[]>
    {
        public IFunc WithImpl(Func<IEnv, IList<IExpr>, string[]> impl) =>
            new InlineFunc(_name, _returnType, BuildArgsValidationAction(), (env, args) => impl(env, args));
    }
    #endregion
}
