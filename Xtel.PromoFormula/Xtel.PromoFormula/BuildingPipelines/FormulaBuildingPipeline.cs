using System.Collections.Generic;
using Xtel.PromoFormula.ExpressionBuilders;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.BuildingPipelines
{
    public class FormulaBuildingPipeline : BuildingPipeline
    {
        // With the StringConcat optimization turn on, the behaviour is the same as in C#
        private const bool ApplyStringConcatOptimization = true;

        protected override IList<IExprBuilder> Builders { get; }
            = new List<IExprBuilder>();

        public FormulaBuildingPipeline(IEnv env)
            : base(env)
        {
            Builders.Add(new ConstantExprBuilder(Env));
            Builders.Add(new GroupExprBuilder(Env));
            Builders.Add(new StringConcatExprBuilder(ApplyStringConcatOptimization, Env)); // must be before `MathExprBuilder`
            Builders.Add(new MathExprBuilder(ApplyStringConcatOptimization, Env));
            Builders.Add(new PlusOrMinusExprBuilder(Env));
            Builders.Add(new ConditionalExprBuilder(Env));
            Builders.Add(new NegationExprBuilder(Env));
            Builders.Add(new LogicalExprBuilder(Env));
            Builders.Add(new ArrayExprBuilder(Env));
            Builders.Add(new FuncExprBuilder(Env));
        }
    }
}
