using MonadLib;

namespace MonadicEvaluatorLib
{
    public class Div : Term
    {
        private readonly Term _term1;
        private readonly Term _term2;

        public Div(Term term1, Term term2)
        {
            _term1 = term1;
            _term2 = term2;
        }

        public override IMonad<int> Eval(MonadAdapter monadAdapter)
        {
            return monadAdapter.Bind(
                _term1.Eval(monadAdapter), a => monadAdapter.Bind(
                    _term2.Eval(monadAdapter), b => monadAdapter.Return(a / b)));
        }
    }
}
