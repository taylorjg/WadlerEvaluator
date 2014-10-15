using System;
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
            Func<string, Either<string, int>> raise = Either<string>.Left<int>;

            return _term1.EvalEither().Bind(
                a => _term2.EvalEither().Bind(
                    b => b == 0 ? raise("divide by zero") : Either<string>.Right(a / b)));
        }

        public override State<int, int> EvalState()
        {
            Func<State<int, Unit>> tick = () => State<int>.Modify(x => x + 1);

            return _term1.EvalState().Bind(
                a => _term2.EvalState().Bind(
                    b => tick().BindIgnoringLeft(State<int>.Return(a / b))));
        }
    }
}
