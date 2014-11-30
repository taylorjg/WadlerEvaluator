using System;
using MonadLib;
using MonadicEvaluatorLib;

namespace MonadicEvaluatorApp
{
    internal class Program
    {
        private static void Main()
        {
            var answer = new Div(new Div(new Constant(1972), new Constant(2)), new Constant(23));
            var error = new Div(new Constant(1), new Constant(0));

            EvalMaybeDemo(answer, "answer.EvalMaybe()");
            EvalMaybeDemo(error, "error.EvalMaybe()");

            Console.WriteLine();

            EvalEitherDemo(answer, "answer.EvalEither()");
            EvalEitherDemo(error, "error.EvalEither()");

            Console.WriteLine();

            EvalStateDemo(answer, "answer.EvalState()");
            EvalStateDemo(error, "error.EvalState()");

            Console.WriteLine();
            
            EvalWriterDemo(answer, "answer.EvalWriter()");
            EvalWriterDemo(error, "error.EvalWriter()");

            Console.WriteLine();
        }

        private static void EvalMaybeDemo(Term t, string label)
        {
            TryEval(() => DisplayMaybeResult(t.EvalMaybe()), label);
        }

        private static void EvalEitherDemo(Term t, string label)
        {
            TryEval(() => DisplayEitherResult(t.EvalEither()), label);
        }

        private static void EvalStateDemo(Term t, string label)
        {
            TryEval(() => DisplayStateResult(t.EvalState().RunState(0)), label);
        }

        private static void EvalWriterDemo(Term t, string label)
        {
            TryEval(() => DisplayWriterResult(t.EvalWriter().RunWriter), label);
        }

        private static void DisplayMaybeResult(Maybe<int> result)
        {
            Console.WriteLine(result.Match(Convert.ToString, () => "Nothing"));
        }

        private static void DisplayEitherResult(Either<string, int> result)
        {
            Console.WriteLine(result.Match(l => l, Convert.ToString));
        }

        private static void DisplayStateResult(Tuple<int, int> result)
        {
            Console.WriteLine(result);
        }

        private static void DisplayWriterResult(Tuple<int, ListMonoid<string>> result)
        {
            Console.WriteLine(result.Item1);
            foreach (var w in result.Item2.List) Console.WriteLine("  {0}", w);
        }

        private static void TryEval(Action action, string label)
        {
            try
            {
                Console.Write("{0}: ", label);
                action();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("EXCEPTION: {0}", ex.Message);
            }
        }
    }
}
