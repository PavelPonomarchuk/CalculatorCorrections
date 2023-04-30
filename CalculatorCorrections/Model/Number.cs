namespace CalculatorCorrections.Model
{
    public class Number : IExpressionNode
    {
        public double Value { get; private set; }

        public Number(double value)
        {
            Value = value;
        }
    }
}
