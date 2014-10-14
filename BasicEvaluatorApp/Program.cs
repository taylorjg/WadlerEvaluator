using System;
using BasicEvaluatorLib;

namespace BasicEvaluatorApp
{
    internal class Program
    {
        private static void Main(/* string[] args */)
        {
            var answer = new Div(new Div(new Constant(1972), new Constant(2)), new Constant(23));
            Console.WriteLine("answer.Eval(): {0}", answer.Eval());

            var error = new Div(new Constant(1), new Constant(0));
            Console.WriteLine("error.Eval(): {0}", error.Eval());
        }
    }
}
