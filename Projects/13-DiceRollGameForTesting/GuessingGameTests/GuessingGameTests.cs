using DiceRollGameForTesting.Game;
using DiceRollGameForTesting.UserCommunication;
using Moq;
using NUnit.Framework;

#nullable disable

namespace GuessingGameTests
{
    [TestFixture]
    public class GuessingGameTests
    {
        private Mock<IDice> _diceMock;
        private Mock<Random> _randomMock;
        private Mock<IUserCommunication> _userCommunicationMock;
        private GuessingGame _cut;

        [SetUp]
        public void SetUp()
        {
            // Setting up the mocks
            _randomMock = new Mock<Random>();

            // Don't forget to pass the mock instance to the constructor.
            // Never pass the class itself that you are testing to the constructor.
            _diceMock = new Mock<IDice>();
            _userCommunicationMock = new Mock<IUserCommunication>();
            _cut = new GuessingGame(_diceMock.Object, _userCommunicationMock.Object);
        }

        [Test]
        public void Play_ReturnsVictory_WhenFirstGuessIsCorrect()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);

            _userCommunicationMock
                .Setup(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(5);

            // Act
            var result = _cut.Play();

            // Assert
            Assert.That(result, Is.EqualTo(GameResult.Victory));
        }



    }
}
