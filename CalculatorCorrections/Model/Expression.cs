namespace CalculatorCorrections.Model
{
    public class Expression : IExpressionNode
    {
        public IExpressionNode LeftChild { get; private set; }
        public IExpressionNode RightChild { get; private set; }
        public Operation Operation { get; private set; }

        public Expression(IExpressionNode leftChild, IExpressionNode rightChild, Operation operation)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
            Operation = operation;
        }
    }
}
