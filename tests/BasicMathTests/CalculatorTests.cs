using CalculatorApp;
using Xunit;

namespace BasicMathTests
{
    public class CalculatorTests
    {
        // Test method for Add operation using inline data
        [Theory]
        [InlineData(1, 2, 3)] // Test case 1: 1 + 2 = 3
        [InlineData(-1, -2, -3)] // Test case 2: -1 + -2 = -3
        [InlineData(0, 0, 0)] // Test case 3: 0 + 0 = 0
        [InlineData(int.MaxValue, 1, int.MinValue)] // Test case 4: Overflow scenario (unchecked)
        public void Add_MultipleValues_ReturnsCorrectSum(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        // Test method for Subtract operation using inline data
        [Theory]
        [InlineData(5, 3, 2)] // Test case 1: 5 - 3 = 2
        [InlineData(-5, -3, -2)] // Test case 2: -5 - -3 = -2
        [InlineData(0, 0, 0)] // Test case 3: 0 - 0 = 0
        [InlineData(int.MinValue, 1, int.MaxValue)] // Test case 4: Underflow scenario
        public void Subtract_MultipleValues_ReturnsCorrectDifference(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Subtract(a, b);
            Assert.Equal(expected, result);
        }

        // Test method for Multiply operation using inline data
        [Theory]
        [InlineData(2, 3, 6)] // Test case 1: 2 * 3 = 6
        [InlineData(-2, -3, 6)] // Test case 2: -2 * -3 = 6
        [InlineData(0, 5, 0)] // Test case 3: 0 * 5 = 0
        [InlineData(int.MaxValue, 1, int.MaxValue)] // Test case 4: Max value scenario
        public void Multiply_MultipleValues_ReturnsCorrectProduct(int a, int b, int expected)
        {
            var calculator = new Calculator();
            int result = calculator.Multiply(a, b);
            Assert.Equal(expected, result);
        }

        // Test method for Divide operation using inline data
        [Theory]
        [InlineData(6, 3, 2.0)] // Test case 1: 6 / 3 = 2
        [InlineData(-6, -3, 2.0)] // Test case 2: -6 / -3 = 2
        [InlineData(0, 1, 0.0)] // Test case 3: 0 / 1 = 0
        [InlineData(int.MaxValue, 1, (double)int.MaxValue)] // Test case 4: Max value scenario
        public void Divide_MultipleValues_ReturnsCorrectQuotient(int a, int b, double expected)
        {
            var calculator = new Calculator();
            double result = calculator.Divide(a, b);
            Assert.Equal(expected, result);
        }
    }
}
