using System;
using BasicEvaluatorLib;

namespace BasicEvaluatorApp
{
    internal class Program
    {
        private static void Main()
        {
            var answer = new Div(new Div(new Constant(1972), new Constant(2)), new Constant(23));
            var error = new Div(new Constant(1), new Constant(0));

            Console.WriteLine("answer.Eval(): {0}", answer.Eval());

            try
            {
                Console.WriteLine("error.Eval(): {0}", error.Eval());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("EXCEPTION: {0}", ex.Message);
            }
        }
    }
}
