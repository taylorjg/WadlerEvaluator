using MonadLib;

namespace MonadicEvaluatorLib
{
    public abstract class Term
    {
        public abstract string Name { get; }
        public abstract string ShowTerm();

        public abstract Maybe<int> EvalMaybe();
        public abstract Either<string, int> EvalEither();
        public abstract State<int, int> EvalState();
        public abstract Writer<ListMonoid<string>, string, int> EvalWriter();

        public string Line(Term t, int a)
        {
            return string.Format("eval ({0}) <= {1}", t.ShowTerm(), a);
        }
    }
}
