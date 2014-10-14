namespace BasicEvaluatorLib
{
    public class Constant : Term
    {
        private readonly int _value;

        public Constant(int value)
        {
            _value = value;
        }

        public override int Eval()
        {
            return _value;
        }
    }
}
