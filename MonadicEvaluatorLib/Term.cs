using MonadLib;

namespace MonadicEvaluatorLib
{
    public abstract class Term
    {
        public abstract IMonad<int> Eval(MonadAdapter monadAdapter);
    }
}
