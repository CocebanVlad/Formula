using CalculationService.BuildingPipelines;
using CalculationService.Environments;
using CalculationService.Exceptions;
using CalculationService.Interfaces;
using CalculationService.Tokenizers;
using System.Linq;
using System.Reflection;

namespace CalculationService
{
    public class CalculationService
    {
        private readonly ITokenizer _tokenizer;
        private readonly IEnv _env;
        private readonly IBuildingPipeline _pipeline;

        public IEnv Env => _env;

        public CalculationService()
        {
            _tokenizer = new FormulaTokenizer();

            var env = new FormulaEnv();
            var executingAsm = Assembly.GetExecutingAssembly();
            env.DiscoverFuncsFromAssembly(executingAsm); // load local functions
            foreach (var name in executingAsm.GetReferencedAssemblies()) // load third-party functions
            {
                env.DiscoverFuncsFromAssembly(Assembly.Load(name.ToString()));
            }
            _env = env;

            _pipeline = new FormulaBuildingPipeline(_env);
        }

        public IExpr Build(string formula)
        {
            var exprs = _pipeline.Build(_tokenizer.Tokenize(formula));
            if (exprs.Count > 1)
            {
                throw new Ex(tr.invalid_formula);
            }

            return exprs.First();
        }
    }
}
