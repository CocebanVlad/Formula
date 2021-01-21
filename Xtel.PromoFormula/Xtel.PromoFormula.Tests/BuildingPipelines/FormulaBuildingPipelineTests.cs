using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xtel.PromoFormula.BuildingPipelines;
using Xtel.PromoFormula.Exceptions;
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
        public void Build_Expr_01_MustReturnExpectedEvalValue()
        {
            IList<IExpr> exprs;

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("((1 + (1 + 1) * 10))"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(21, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("((1) + (1 + 1)) * 10"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(30, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("(((1 + 1 + 1 * 10)))"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(12, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("((6 / (2 % 4) * 10))"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(30, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("108.9e7 + 1 * 10 / 2"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(1089000005, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("1.3 * 1.3 * 1.3 * 12"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(26.364000000000004, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("+-+-+-+-+-+1"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(-1, (double)exprs.First().Eval(null));

            exprs = _buildingPipeline.Build(_tokenizer.Tokenize("-1 + -1"));
            Assert.AreEqual(1, exprs.Count);
            Assert.AreEqual(-2, (double)exprs.First().Eval(null));
        }

        [TestMethod]
        public void Build_Expr_01_MustThrowException()
        {
            Assert.ThrowsException<BuildEx>(() =>
                _buildingPipeline.Build(_tokenizer.Tokenize("((1 + (1 + 1) * 10()")));

            Assert.ThrowsException<BuildEx>(() =>
                _buildingPipeline.Build(_tokenizer.Tokenize("() + 1")));

            Assert.ThrowsException<BuildEx>(() =>
                _buildingPipeline.Build(_tokenizer.Tokenize("1 - (+) - 1")));

            Assert.ThrowsException<BuildEx>(() =>
                _buildingPipeline.Build(_tokenizer.Tokenize("((1) + (1)) + 1) * 10")));

            Assert.ThrowsException<BuildEx>(() =>
                _buildingPipeline.Build(_tokenizer.Tokenize("+-+-+-+-+--1")));

            Assert.ThrowsException<BuildEx>(() =>
                _buildingPipeline.Build(_tokenizer.Tokenize("(1)-1)")));
        }
    }
}
