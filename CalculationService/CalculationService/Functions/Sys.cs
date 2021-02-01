using CalculationService.Interfaces;
using System;
using System.Linq;

namespace CalculationService.Functions
{
    [FuncRepository]
    public static class Sys
    {
        public static IFunc Sum = FuncBuilder.Create()
            .WithName("Sum")
            .WithArg(Enums.Type.NumberArray)
            .ReturnNumber()
            .WithImpl((env, args) => ((double[])args[0].Eval()).Sum());

        public static IFunc Pow = FuncBuilder.Create()
            .WithName("Pow")
            .WithArg(Enums.Type.Number)
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Pow((double)args[0].Eval(), (double)args[1].Eval()));

        public static IFunc Sqrt = FuncBuilder.Create()
            .WithName("Sqrt")
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Sqrt((double)args[0].Eval()));

        public static IFunc Trunc = FuncBuilder.Create()
            .WithName("Trunc")
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Truncate((double)args[0].Eval()));

        public static IFunc Round = FuncBuilder.Create()
            .WithName("Round")
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Round((double)args[0].Eval(), MidpointRounding.AwayFromZero));

        public static IFunc Ceil = FuncBuilder.Create()
            .WithName("Ceil")
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Ceiling((double)args[0].Eval()));

        public static IFunc Min = FuncBuilder.Create()
            .WithName("Min")
            .WithArg(Enums.Type.Number)
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Min((double)args[0].Eval(), (double)args[1].Eval()));

        public static IFunc Max = FuncBuilder.Create()
            .WithName("Max")
            .WithArg(Enums.Type.Number)
            .WithArg(Enums.Type.Number)
            .ReturnNumber()
            .WithImpl((env, args) => Math.Max((double)args[0].Eval(), (double)args[1].Eval()));

        public static IFunc Iif = FuncBuilder.Create()
            .WithName("Iif")
            .WithArg(Enums.Type.Bool)
            .WithArg(Enums.Type.Any)
            .WithArg(Enums.Type.Any)
            .ReturnAny()
            .WithImpl((env, args) => (bool)args[0].Eval() ? args[1].Eval() : args[2].Eval());

        public static IFunc AsAny = FuncBuilder.Create()
            .WithName("AsAny")
            .WithArg(Enums.Type.Any)
            .ReturnAny()
            .WithImpl((env, args) => args[0].Eval());
    }
}
