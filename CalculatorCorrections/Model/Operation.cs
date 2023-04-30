using System;

namespace CalculatorCorrections.Model
{
    public class Operation
    {
        public OperationType Type { get; private set; }
        public string Representation { get; private set; }
        public Func<double, double, double> Action { get; private set; }
        public int Priority { get; private set; }

        public Operation(OperationType type, string representation, Func<double, double, double> action, int priority)
        {
            Type = type;
            Representation = representation;
            Action = action;
            Priority = priority;
        }
    }
}
