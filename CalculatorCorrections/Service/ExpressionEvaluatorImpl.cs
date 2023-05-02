using CalculatorCorrections.Model;
using System;

namespace CalculatorCorrections.Service
{
    public class ExpressionEvaluatorImpl : IExpressionEvaluator
    {
        public double Evaluate(IExpressionNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }            

            if (root is Number number)
            {
                return number.Value;
            } else
            {
                var expression = root as Expression;
                var leftArg = Evaluate(expression.LeftChild);
                var rightArg = Evaluate(expression.RightChild);

                return expression.Operation.Action.Invoke(leftArg, rightArg);
            }
        }
    }
}
