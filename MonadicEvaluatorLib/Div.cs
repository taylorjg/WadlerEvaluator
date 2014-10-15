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

        public override Maybe<int> EvalMaybe()
        {
            return _term1.EvalMaybe().Bind(
                a => _term2.EvalMaybe().Bind(
                    b => b == 0 ? Maybe.Nothing<int>() : Maybe.Just(a / b)));
        }

        public override Either<string, int> EvalEither()
        {
            return _term1.EvalEither().Bind(
                a => _term2.EvalEither().Bind(
                    b => b == 0 ? Either<string>.Left<int>("divide by zero") : Either<string>.Right(a / b)));
        }
    }
}
