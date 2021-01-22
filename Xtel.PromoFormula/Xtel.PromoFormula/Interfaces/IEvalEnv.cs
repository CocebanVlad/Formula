namespace Xtel.PromoFormula.Interfaces
{
    public interface IEvalEnv
    {
        object ExecFn(in string name, object[] args);
    }
}
