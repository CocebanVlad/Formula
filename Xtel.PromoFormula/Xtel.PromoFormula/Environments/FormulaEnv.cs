using CalculationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CalculationService.Environments
{
    public class FormulaEnv : Env
    {
        public override IDictionary<string, IFunc> Functions { get; }
            = new Dictionary<string, IFunc>(StringComparer.InvariantCultureIgnoreCase);

        public FormulaEnv()
        {
        }

        public void DiscoverFuncsFromAssembly(Assembly asm)
        {
            var types =
                asm.GetTypes();

            foreach (var t in types)
            {
                if (t.GetCustomAttributes<FuncRepositoryAttribute>(false).Any())
                {
                    var fields = t.GetFields(BindingFlags.Public | BindingFlags.Static);
                    foreach (var f in fields)
                    {
                        if (typeof(IFunc).IsAssignableFrom(f.FieldType))
                        {
                            RegisterFunc((IFunc)f.GetValue(null));
                        }
                    }
                }
            }
        }
    }
}
