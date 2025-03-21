using NUnit.Framework;

namespace FibonacciTests
{
    [TestFixture]
    public class FibonacciUnitTests
    {

        [TestCase(-1)]
        [TestCase(-2)]
        public void Generate_ThrowsArgumentException_IfNIsSmallerThanZero(int number)
        {
            Assert.That(() => Fibonacci.Generate(number),
                Throws.ArgumentException);
        }

        [TestCase(47)]
        [TestCase(48)]
        public void Generate_ThrowsArgumentException_IfNIsGreaterThan46(int number)
        {
            Assert.That(() => Fibonacci.Generate(47),
                Throws.ArgumentException);
        }

        [TestCase(0, new int[] { })]
        public void Generate_ReturnsEmptyArray_IfInputIsZero(int number, int[] expected)
        {
            var result = Fibonacci.Generate(number);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(1, new int[] { 0 })]
        [TestCase(2, new int[] { 0, 1 })]
        public void Generate_ReturnsExpectedResult_IfInputIsValid(int number, int[] expected)
        {
            var result = Fibonacci.Generate(number);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(46, 1134903170)]
        public void Generate_LastItemEqualsExpected_IfInputIs46(int number, int expectedLastItem)
        {
            var result = Fibonacci.Generate(number);
            Assert.That(result.Last(), Is.EqualTo(expectedLastItem));
        }
    }
}
