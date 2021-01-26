using System.Collections.Generic;
using Xtel.PromoFormula.ExpressionBuilders;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.BuildingPipelines
{
    public class FormulaBuildingPipeline : BuildingPipeline
    {
        // With the StringConcat optimization turn on, the behaviour is the same as in C#
        private const bool ApplyStringConcatOptimization = true;

        protected override IList<IExprBuilder> Builders => new List<IExprBuilder>()
        {
            new ConstantExprBuilder(),
            new GroupExprBuilder(),
            new StringConcatExprBuilder(ApplyStringConcatOptimization), // must be before `MathExprBuilder`
            new MathExprBuilder(ApplyStringConcatOptimization),
            new PlusOrMinusExprBuilder(),
            new ConditionalExprBuilder(),
            new NegationExprBuilder(),
            new LogicalExprBuilder(),
        };
    }
}
