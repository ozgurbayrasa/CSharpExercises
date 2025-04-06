using Moq;
using NUnit.Framework;


// Since it is a test file, we can safely ignore nullability warnings
#nullable disable
namespace RandPasswordGeneratorUnitTests
{
    [TestFixture]
    public class RandomPasswordGeneratorUnitTests
    {
        private PasswordGenerator _cut; // Class under test
        private Mock<IRandomProvider> _randomProviderMock;

        [SetUp]
        public void SetUp()
        {
            _randomProviderMock = new Mock<IRandomProvider>();
            _cut = new PasswordGenerator(_randomProviderMock.Object);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Generate_ShallThrowArgumentOutOfRangeException_WhenMinValueLessThan1(int minvalue)
        {
            bool isSpecialLetter = false;
            int maxValue = 5;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _cut.Generate(minvalue, maxValue, isSpecialLetter));
        }

        [TestCase(5,4)]
        [TestCase(-1,-5)]
        public void Generate_ShallThrowArgumentOutOfRangeException_WhenMinValueGreaterThanMaxValue(int minvalue, int maxValue)
        {
            bool isSpecialLetter = false;
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _cut.Generate(minvalue, maxValue, isSpecialLetter));
        }

        [TestCase(2, 5)]
        [TestCase(1, 1)]
        public void Generate_ShallNotThrowException_WhenMinValueGreaterThan0AndLessOrEqualThanMaxValue(int minvalue, int maxValue)
        {
            bool isSpecialLetter = false;

            // Act & Assert
            Assert.DoesNotThrow(() => _cut.Generate(minvalue, maxValue, isSpecialLetter));
        }


        

    }
}
