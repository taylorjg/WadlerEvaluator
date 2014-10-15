using System;
using MonadLib;
using MonadicEvaluatorLib;

namespace MonadicEvaluatorApp
{
    internal class Program
    {
        private static void Main( /* string[] args */)
        {
            var answer = new Div(new Div(new Constant(1972), new Constant(2)), new Constant(23));
            var error = new Div(new Constant(1), new Constant(0));

            EvalMaybeDemo(answer, error);
            EvalEitherDemo(answer, error);
            EvalStateDemo(answer, error);
        }

        private static void EvalMaybeDemo(Term answer, Term error)
        {
            DisplayResult(answer.EvalMaybe(), "answer.EvalMaybe()");
            DisplayResult(error.EvalMaybe(), "error.EvalMaybe()");
        }

        private static void EvalEitherDemo(Term answer, Term error)
        {
            DisplayResult(answer.EvalEither(), "answer.EvalEither()");
            DisplayResult(error.EvalEither(), "error.EvalEither()");
        }

        private static void EvalStateDemo(Term answer, Term error)
        {
            DisplayResult(answer.EvalState().RunState(0), "answer.EvalState()");
            DisplayResult(error.EvalState().RunState(0), "error.EvalState()");
        }

        private static void DisplayResult(Maybe<int> result, string label)
        {
            Console.WriteLine("{0}: {1}", label, result.Match(Convert.ToString, () => "Nothing"));
        }

        private static void DisplayResult(Either<string, int> result, string label)
        {
            Console.WriteLine("{0}: {1}", label, result.Match(l => l, Convert.ToString));
        }

        private static void DisplayResult(Tuple<int, int> result, string label)
        {
            Console.WriteLine("{0}: {1}", label, result);
        }
    }
}
