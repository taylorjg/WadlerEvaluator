using System;
using MonadLib;
using MonadicEvaluatorLib;

namespace MonadicEvaluatorApp
{
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            var answer = new Div(new Div(new Constant(1972), new Constant(2)), new Constant(23));
            var result = (Maybe<int>)answer.Eval(Maybe.Return(0).GetMonadAdapter());
            Console.WriteLine("answer.Eval(): {0}", result.Match(Convert.ToString, () => "Nothing"));
        }
    }
}
