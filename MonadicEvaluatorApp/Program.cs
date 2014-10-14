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
            var result1 = (Maybe<int>) answer.Eval(Maybe.Return(0).GetMonadAdapter());
            Console.WriteLine("answer.Eval(): {0}", result1.Match(Convert.ToString, () => "Nothing"));

            var error = new Div(new Constant(1), new Constant(0));
            var result2 = (Maybe<int>) error.Eval(Maybe.Return(0).GetMonadAdapter());
            Console.WriteLine("error.Eval(): {0}", result2.Match(Convert.ToString, () => "Nothing"));
        }
    }
}
