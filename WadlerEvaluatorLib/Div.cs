namespace WadlerEvaluatorLib
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

        public override int Eval()
        {
            return _term1.Eval() / _term2.Eval();
        }
    }
}
