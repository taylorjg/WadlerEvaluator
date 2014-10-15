using MonadLib;

namespace MonadicEvaluatorLib
{
    public abstract class Term
    {
        public abstract Maybe<int> EvalMaybe();
        public abstract Either<string, int> EvalEither();
        public abstract State<int, int> EvalState();
    }
}
