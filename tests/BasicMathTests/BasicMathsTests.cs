using BasicMath;
using Xunit;

namespace BasicMathTests
{
    public class BasicMathsTests
    {
        // Exercise 1: Equivalence Partitioning (EP) and Boundary Value Analysis (BVA)
        [Theory]
        [InlineData(1, 1, 2)] // EP: Positive numbers
        [InlineData(-1, -1, -2)] // EP: Negative numbers
        [InlineData(0, 0, 0)] // EP: Zero
        [InlineData(int.MaxValue, 1, (double)int.MaxValue + 1)] // BVA: Upper boundary
        [InlineData(int.MinValue, -1, (double)int.MinValue - 1)] // BVA: Lower boundary
        public void Test_AddMV(int a, int b, double expected)
        {
            var bm = new BasicMaths();
            double actual = bm.Add(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 5, 5)] // EP: Positive
        [InlineData(-10, -5, -5)] // EP: Negative
        [InlineData(5, 5, 0)] // EP: Zero result
        [InlineData(int.MaxValue, 1, (double)int.MaxValue - 1)] // BVA: Upper boundary
        [InlineData(int.MinValue, 1, (double)int.MinValue - 1)] // BVA: Lower boundary
        public void Test_SubtractMV(int a, int b, double expected)
        {
            var bm = new BasicMaths();
            double actual = bm.Subtract(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 4, 12)] // EP: Positive
        [InlineData(-3, 4, -12)] // EP: Negative
        [InlineData(0, 100, 0)] // EP: Zero
        public void Test_MultiplyMV(int a, int b, double expected)
        {
            var bm = new BasicMaths();
            double actual = bm.Multiply(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(20, 5, 4)] // EP: Positive
        [InlineData(-20, 5, -4)] // EP: Negative
        [InlineData(0, 5, 0)] // EP: Zero numerator
        public void Test_DivideMV(int a, int b, double expected)
        {
            var bm = new BasicMaths();
            double actual = bm.Divide(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_DivideByZero_ThrowsException()
        {
            var bm = new BasicMaths();
            Assert.Throws<DivideByZeroException>(() => bm.Divide(10, 0));
        }
    }
}
