using Moq;
using NUnit.Framework;


// Since it is a test file, we can safely ignore nullability warnings
#nullable disable
namespace RandPasswordGeneratorUnitTests
{
    [TestFixture]
    public class RandomPasswordGeneratorUnitTests
    {
        private string allowedCharactersOnlyNonSpeacials = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string allowedCharactersWithSpecials = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=";

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

        [TestCase(true)]
        public void Generate_ShallIncludeSpecialLetters_IfIsSpeacialLetterIsTrue(bool isSpeacialLetter)
        {
            // Arrange
            int minValue = 5;
            int maxValue = 10;

            int fixedLength = 5;

            SetupRandomToSelectFixedLenght(fixedLength);
            SetupRandomToSelectCharacterIndex(allowedCharactersWithSpecials.Length - 1);

            // Act
            var result = _cut.Generate(minValue, maxValue, isSpeacialLetter);
            
            // Assert
            Assert.That(result.All(passwordCharacter => allowedCharactersWithSpecials.Contains(passwordCharacter)));
        }

        [TestCase(false)]
        public void Generate_ShallNotIncludeSpecialLetters_IfIsSpeacialLetterIsFalse(bool isSpeacialLetter)
        {
            // Arrange
            int minValue = 5;
            int maxValue = 10;

            int fixedLength = 5;

            SetupRandomToSelectFixedLenght(fixedLength);
            SetupRandomToSelectCharacterIndex(allowedCharactersOnlyNonSpeacials.Length - 1);


            // Act
            var result = _cut.Generate(minValue, maxValue, isSpeacialLetter);
            // Assert
            Assert.That(result.All(passwordCharacter => allowedCharactersOnlyNonSpeacials.Contains(passwordCharacter) && 
                                                        !allowedCharactersWithSpecials.Contains(passwordCharacter)));
        }

        private void SetupRandomToSelectCharacterIndex(int index)
        {
            var sequence = _randomProviderMock.Setup(mock => mock.Next(It.IsAny<int>()));
            sequence.Returns(index); 
        }

        private void SetupRandomToSelectFixedLenght(int lenght)
        {
            var sequence = _randomProviderMock.Setup(mock => mock.Next(It.IsAny<int>(), It.IsAny<int>()));
            sequence.Returns(lenght);
        }


    }
}
