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

        public override Maybe<int> EvalMaybe()
        {
            return Maybe.Return(_value);
        }

        public override Either<string, int> EvalEither()
        {
            return Either<string>.Return(_value);
        }

        public override State<int, int> EvalState()
        {
            return State<int>.Return(_value);
        }
    }
}
