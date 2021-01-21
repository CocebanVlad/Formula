using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xtel.PromoFormula.BuildingPipelines;
using Xtel.PromoFormula.Interfaces;
using Xtel.PromoFormula.Tokenizers;

namespace Xtel.PromoFormula.Tests.BuildingPipelines
{
    [TestClass]
    public class FormulaBuildingPipelineTests
    {
        private ITokenizer _tokenizer;
        private IBuildingPipeline _buildingPipeline;

        public FormulaBuildingPipelineTests()
        {
            _tokenizer = new FormulaTokenizer();
            _buildingPipeline = new FormulaBuildingPipeline();
        }

        [TestMethod]
        public void Build_MathExpr_MustReturnExpectedExpr()
        {
            var exprs = _buildingPipeline.Build(_tokenizer.Tokenize("1 + 1"));
        }
    }
}
