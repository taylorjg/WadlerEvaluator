using MonadLib;

namespace MonadicEvaluatorLib
{
    public class Constant : Term
    {
        private readonly int _value;

        public Constant(int value)
        {
            _value = value;
        }

        public override IMonad<int> Eval(MonadAdapter monadAdapter)
        {
            return monadAdapter.Return(_value);
        }
    }
}
