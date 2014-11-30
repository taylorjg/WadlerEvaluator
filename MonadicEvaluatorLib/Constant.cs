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

        public override string Name
        {
            get { return "Con"; }
        }

        public override string ShowTerm()
        {
            return string.Format("{0} {1}", Name, _value);
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

        public override Writer<ListMonoid<string>, string, int> EvalWriter()
        {
            return Writer<ListMonoid<string>, string>.Tell(new ListMonoid<string>(Line(this, _value))).BindIgnoringLeft(
                Writer<ListMonoid<string>, string>.Return(_value));
        }
    }
}
