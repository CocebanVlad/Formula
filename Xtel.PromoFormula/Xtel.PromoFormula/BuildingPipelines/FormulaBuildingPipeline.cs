using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.ExpressionBuilders;
using Xtel.PromoFormula.Interfaces;

namespace Xtel.PromoFormula.BuildingPipelines
{
    public class FormulaBuildingPipeline : BuildingPipeline
    {
        protected override IList<IExprBuilder> Builders => new List<IExprBuilder>()
        {
            new ConstantExprBuilder(),
            new GroupExprBuilder(),
            new MathExprBuilder(),
            new PlusOrMinusExprBuilder(),
        };
    }
}
