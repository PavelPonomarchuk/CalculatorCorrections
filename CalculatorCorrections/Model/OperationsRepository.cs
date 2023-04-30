using System.Collections.Generic;

namespace CalculatorCorrections.Model
{
    public class OperationsRepository
    {
        private readonly HashSet<Operation> operations = new HashSet<Operation>();

        public OperationsRepository()
        {
            CreateAdditionOperation();
            CreateSubstractionOperation();
            CreateMultiplicationOperation();
            CreateDivisionOperation();
        }

        private void CreateAdditionOperation()
        {
            double funcAdd(double x, double y) => x + y;
            var addition = new Operation(OperationType.Addition, "+", funcAdd, 1);
            operations.Add(addition);
        }

        private void CreateSubstractionOperation()
        {
            double funcSubstract(double x, double y) => x - y;
            var substraction = new Operation(OperationType.Substraction, "-", funcSubstract, 1);
            operations.Add(substraction);
        }

        private void CreateMultiplicationOperation()
        {
            double funcMultiply(double x, double y) => x * y;
            var multiplication = new Operation(OperationType.Multiplication, "*", funcMultiply, 2);
            operations.Add(multiplication);
        }

        private void CreateDivisionOperation()
        {
            double funcDivide(double x, double y) => x / y;
            var division = new Operation(OperationType.Division, "/", funcDivide, 2);
            operations.Add(division);
        }

        public bool OperationExists(string representation)
        {
            foreach (Operation op in operations)
            {
                if (op.Representation == representation)
                    return true;
            }
            return false;
        }

        public Operation GetOperation(string representation)
        {
            foreach (Operation op in operations)
            {
                if (op.Representation == representation)
                    return op;
            }
            return null;
        }
    }
}
