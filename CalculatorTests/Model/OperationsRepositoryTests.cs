using CalculatorCorrections.Model;

namespace CalculatorTests.Model
{
    public class OperationsRepositoryTests
    {
        private OperationsRepository opRepo;

        [SetUp]
        public void Setup()
        {
            opRepo = new OperationsRepository();
        }

        [Test]
        public void CheckAdditionExists()
        {
            var exists = opRepo.OperationExists("+");
            Assert.That(exists, Is.True);
        }

        [Test]
        public void CheckSubstractionExists()
        {
            var exists = opRepo.OperationExists("-");
            Assert.That(exists, Is.True);
        }

        [Test]
        public void CheckMultiplicationExists()
        {
            var exists = opRepo.OperationExists("*");
            Assert.That(exists, Is.True);
        }

        [Test]
        public void CheckDivisionExists()
        {
            var exists = opRepo.OperationExists("/");
            Assert.That(exists, Is.True);
        }

        [Test]
        public void CheckUnknownOperationExists()
        {
            var exists = opRepo.OperationExists("no such operation");
            Assert.That(exists, Is.False);
        }

        [Test]
        public void GetAddition()
        {
            var addition = opRepo.GetOperation("+");
            if (addition == null)
            {
                Assert.Fail();
                return;
            }
            
            var isCorrect = addition.Representation == "+" &&
                addition.Type == OperationType.Addition &&
                addition.Priority == 1;

            Assert.That(isCorrect, Is.True);
        }

        [Test]
        public void GetSubstraction()
        {
            var substraction = opRepo.GetOperation("-");
            if (substraction == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrect = substraction.Representation == "-" &&
                substraction.Type == OperationType.Substraction &&
                substraction.Priority == 1;

            Assert.That(isCorrect, Is.True);
        }

        [Test]
        public void GetMultiplication()
        {
            var multiplication = opRepo.GetOperation("*");
            if (multiplication == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrect = multiplication.Representation == "*" &&
                multiplication.Type == OperationType.Multiplication &&
                multiplication.Priority == 2;

            Assert.That(isCorrect, Is.True);
        }

        [Test]
        public void GetDivision()
        {
            var division = opRepo.GetOperation("/");
            if (division == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrect = division.Representation == "/" &&
                division.Type == OperationType.Division &&
                division.Priority == 2;

            Assert.That(isCorrect, Is.True);
        }

        [Test]
        public void GetUnknownOperation()
        {
            var unknownOp = opRepo.GetOperation("no such operation");
            if (unknownOp == null)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void CorrectAddition()
        {
            var addition = opRepo.GetOperation("+");
            if (addition == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrectAction = CheckOperationResult(addition.Action, 2.0, 2.0, 4.0) &&
                CheckOperationResult(addition.Action, 2.0, 0, 2.0) &&
                CheckOperationResult(addition.Action, 0, -2.0, -2.0);

            Assert.That(isCorrectAction, Is.True);
        }

        [Test]
        public void CorrectSubstraction()
        {
            var subctraction = opRepo.GetOperation("-");
            if (subctraction == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrectAction = CheckOperationResult(subctraction.Action, 4.0, 2.0, 2.0) &&
                CheckOperationResult(subctraction.Action, 2.0, 0, 2.0) &&
                CheckOperationResult(subctraction.Action, 0, 2.0, -2.0) &&
                CheckOperationResult(subctraction.Action, 0, -2.0, 2.0);

            Assert.That(isCorrectAction, Is.True);
        }

        [Test]
        public void CorrectMultiplication()
        {
            var multiplication = opRepo.GetOperation("*");
            if (multiplication == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrectAction = CheckOperationResult(multiplication.Action, 2.0, 2.0, 4.0) &&
                CheckOperationResult(multiplication.Action, 2.0, 0, 0) &&
                CheckOperationResult(multiplication.Action, 0, 2.0, 0) &&
                CheckOperationResult(multiplication.Action, -2.0, -2.0, 4.0) &&
                CheckOperationResult(multiplication.Action, -2.0, 2.0, -4.0);

            Assert.That(isCorrectAction, Is.True);
        }

        [Test]
        public void CorrectDivision()
        {
            var division = opRepo.GetOperation("/");
            if (division == null)
            {
                Assert.Fail();
                return;
            }

            var isCorrectAction = CheckOperationResult(division.Action, 4.0, 2.0, 2.0) &&
                CheckOperationResult(division.Action, 2.0, 2.0, 1.0) &&
                CheckOperationResult(division.Action, 0, 2.0, 0) &&
                CheckOperationResult(division.Action, -2.0, 1.0, -2.0);

            Assert.That(isCorrectAction, Is.True);
        }

        [Test]
        public void CorrectDivisionByZero()
        {
            var division = opRepo.GetOperation("/");
            if (division == null)
            {
                Assert.Fail();
                return;
            }

            var result = division.Action.Invoke(1.0, 0);
            Assert.That(double.IsInfinity(result), Is.True);
        }

        private static bool CheckOperationResult(Func<double, double, double> action, double x, double y, double result)
        {
            return action.Invoke(x, y) == result;
        }
    }
}
