using CalculatorCorrections.Model;

namespace CalculatorCorrections.Service
{
    public interface IExpressionEvaluator
    {
        double Evaluate(IExpressionNode root);
    }
}
