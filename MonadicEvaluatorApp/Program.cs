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
            Console.Write("{0}: ", label);
            DisplayResult(t.EvalMaybe());
        }

        private static void EvalEitherDemo(Term t, string label)
        {
            Console.Write("{0}: ", label);
            DisplayResult(t.EvalEither());
        }

        private static void EvalStateDemo(Term t, string label)
        {
            try
            {
                Console.Write("{0}: ", label);
                DisplayResult(t.EvalState().RunState(0));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("EXCEPTION: {0}", ex.Message);
            }
        }

        private static void EvalWriterDemo(Term t, string label)
        {
            try
            {
                Console.Write("{0}: ", label);
                DisplayResult(t.EvalWriter().RunWriter);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("EXCEPTION: {0}", ex.Message);
            }
        }

        private static void DisplayResult(Maybe<int> result)
        {
            Console.WriteLine(result.Match(Convert.ToString, () => "Nothing"));
        }

        private static void DisplayResult(Either<string, int> result)
        {
            Console.WriteLine(result.Match(l => l, Convert.ToString));
        }

        private static void DisplayResult(Tuple<int, int> result)
        {
            Console.WriteLine(result);
        }

        private static void DisplayResult(Tuple<int, ListMonoid<string>> result)
        {
            Console.WriteLine(result.Item1);
            foreach (var w in result.Item2.List) Console.WriteLine("  {0}", w);
        }
    }
}
