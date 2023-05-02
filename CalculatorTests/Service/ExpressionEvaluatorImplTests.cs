using CalculatorCorrections.Model;
using CalculatorCorrections.Service;

namespace CalculatorTests.Service
{
    public class ExpressionEvaluatorImplTests
    {
        private readonly OperationsRepository opRepo = new();
        private readonly ExpressionEvaluatorImpl evaluator = new();

        [Test]
        public void ThrowsArgumentNullException()
        {            
            Assert.Throws<ArgumentNullException>(() => evaluator.Evaluate(null));
        }

        [Test]
        public void TwiceTwo()
        {
            var op = opRepo.GetOperation("*");

            var left = new Number(2);
            var right = new Number(2);
            var root = new Expression(left, right, op);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(4.0));
        }

        [Test]
        public void SingleNumber()
        {
            var root = new Number(1);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(1.0));
        }

        [Test]
        public void ThreeLevelTree()
        {
            var opSubstraction = opRepo.GetOperation("-");
            var opMultiplication = opRepo.GetOperation("*");

            var lowerLeft = new Number(4);
            var lowerRight = new Number(2);
            var middleLeft = new Expression(lowerLeft, lowerRight, opSubstraction);
            var middleRight = new Number(2);
            var root = new Expression(middleLeft, middleRight, opMultiplication);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(4.0));
        }

        
        [Test]
        public void DivisionByZero()
        {
            var opMultiplication = opRepo.GetOperation("*");
            var opDivision = opRepo.GetOperation("/");

            var lowerLeft = new Number(2);
            var lowerRight = new Number(2);
            var middleLeft = new Expression(lowerLeft, lowerRight, opMultiplication);
            var middleRight = new Number(0);
            var root = new Expression(middleLeft, middleRight, opDivision);

            Assert.Throws<DivideByZeroException>(() => evaluator.Evaluate(root));
        }

        [Test]
        public void DivisionByCalculatedZero()
        {
            var opSubstraction = opRepo.GetOperation("-");
            var opDivision = opRepo.GetOperation("/");

            var lowerLeft = new Number(2);
            var lowerRight = new Number(2);
            var middleLeft = new Number(1);
            var middleRight = new Expression(lowerLeft, lowerRight, opSubstraction);
            var root = new Expression(middleLeft, middleRight, opDivision);

            Assert.Throws<DivideByZeroException>(() => evaluator.Evaluate(root));
        }

        [Test]
        public void RightSubtree()
        {
            var opAttraction = opRepo.GetOperation("+");
            var opDivision = opRepo.GetOperation("/");

            var lowerLeft = new Number(2);
            var lowerRight = new Number(2);
            var middleLeft = new Number(1);
            var middleRight = new Expression(lowerLeft, lowerRight, opAttraction);
            var root = new Expression(middleLeft, middleRight, opDivision);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(0.25));
        }

        [Test]
        public void RightToLeftSubtree()
        {
            var opMultiplication = opRepo.GetOperation("*");
            var opAttraction = opRepo.GetOperation("+");
            var opSubstraction = opRepo.GetOperation("-");

            var fourthLevelLeft = new Number(2);
            var fourthLevelRight = new Number(2);
            var thirdLevelLeft = new Expression(fourthLevelLeft, fourthLevelRight, opAttraction);
            var thirdLevelRight = new Number(2);
            var secondLevelLeft = new Number(2);
            var secondLevelRight = new Expression(thirdLevelLeft, thirdLevelRight, opSubstraction);
            var root = new Expression(secondLevelLeft, secondLevelRight, opMultiplication);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(4.0));
        }

        [Test]
        public void NegativeNumbersProcessing()
        {
            var opMultiplication = opRepo.GetOperation("*");
            var opAttraction = opRepo.GetOperation("+");
            var opSubstraction = opRepo.GetOperation("-");

            var fourthLevelLeft = new Number(-1);
            var fourthLevelRight = new Number(-1);
            var thirdLevelLeft = new Expression(fourthLevelLeft, fourthLevelRight, opAttraction);
            var thirdLevelRight = new Number(-5);
            var secondLevelLeft = new Number(-2);
            var secondLevelRight = new Expression(thirdLevelLeft, thirdLevelRight, opSubstraction);
            var root = new Expression(secondLevelLeft, secondLevelRight, opMultiplication);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(-6.0));
        }

        [Test]
        public void ZeroOperationsProcessing()
        {
            var opMultiplication = opRepo.GetOperation("*");
            var opAttraction = opRepo.GetOperation("+");
            var opSubstraction = opRepo.GetOperation("-");

            var fourthLevelLeft = new Number(2);
            var fourthLevelRight = new Number(0);
            var thirdLevelLeft = new Expression(fourthLevelLeft, fourthLevelRight, opAttraction);
            var thirdLevelRight = new Number(0);
            var secondLevelLeft = new Number(0);
            var secondLevelRight = new Expression(thirdLevelLeft, thirdLevelRight, opSubstraction);
            var root = new Expression(secondLevelLeft, secondLevelRight, opMultiplication);

            Assert.That(evaluator.Evaluate(root), Is.EqualTo(0));
        }
    }
}
