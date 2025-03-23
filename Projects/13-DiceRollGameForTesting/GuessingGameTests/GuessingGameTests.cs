using System.Reflection;
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

        [Test]
        public void Play_ReturnsVictory_WhenSecondGuessIsCorrect()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);

            _userCommunicationMock
                .SetupSequence(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(5);

            // Act
            var result = _cut.Play();

            // Assert
            Assert.That(result, Is.EqualTo(GameResult.Victory));
        }

        [Test]
        public void Play_ReturnsLoss_WhenFourthGuessIsCorrect()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);

            _userCommunicationMock
                .SetupSequence(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(2)
                .Returns(3)
                .Returns(5);

            // Act
            var result = _cut.Play();

            // Assert
            Assert.That(result, Is.EqualTo(GameResult.Loss));
        }

        [Test]
        public void Play_ReturnsVictory_WhenLastGuessIsCorrect()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);

            _userCommunicationMock
                .SetupSequence(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(2)
                .Returns(5);

            // Act
            var result = _cut.Play();

            // Assert
            Assert.That(result, Is.EqualTo(GameResult.Victory));
        }

        [Test]
        public void Play_ReturnsLoss_WhenAllGuessesAreIncorrect()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);

            _userCommunicationMock
                .SetupSequence(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(2)
                .Returns(4);

            // Act
            var result = _cut.Play();

            // Assert
            Assert.That(result, Is.EqualTo(GameResult.Loss));
        }

        [Test]
        public void Play_ShowsMessageWrongNumber3Times_WhenAllGuessesAreIncorrect()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);

            _userCommunicationMock
                .SetupSequence(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(2)
                .Returns(4);

            // Act
            var result = _cut.Play();

            // Assert
            _userCommunicationMock.Verify(u => u.ShowMessage("Wrong number."), Times.Exactly(3));
        }

        [Test]
        public void PrintResult_ShowsMessageYouWin_WhenGameResultIsVictory()
        {
            // Arrange
            var gameResult = GameResult.Victory;
            string expectedMessage = "You win!";
            string actualMessage = string.Empty;

            _userCommunicationMock
                .Setup(u => u.ShowMessage(It.IsAny<string>()))
                .Callback<string>(msg => actualMessage = msg);

            // Act
            _cut.PrintResult(gameResult);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void PrintResult_ShowsMessageYouLose_WhenGameResultIsLoss()
        {
            // Arrange
            var gameResult = GameResult.Loss;
            string expectedMessage = "You lose :(";
            string actualMessage = string.Empty;

            _userCommunicationMock
                .Setup(u => u.ShowMessage(It.IsAny<string>()))
                .Callback<string>(msg => actualMessage = msg);

            // Act
            _cut.PrintResult(gameResult);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Play_ShowsWelcomeMessage_WhenGameStarts()
        {
           
            // Act
            _cut.Play();
            // Assert
            _userCommunicationMock.Verify(u => u.ShowMessage("Dice rolled. Guess what number it shows in 3 tries."), Times.Once);
        }

        [Test]
        public void Play_ShowsEnterANumberMessage_WhenGameStarts()
        {
            // Arrange
            _diceMock
                .Setup(d => d.Roll())
                .Returns(5);
            _userCommunicationMock
                .SetupSequence(u => u.ReadInteger(It.IsAny<string>()))
                .Returns(1)
                .Returns(2)
                .Returns(4);
            // Act
            _cut.Play();
            // Assert
            _userCommunicationMock.Verify(u => u.ReadInteger(Resource.), Times.Exactly(3));
        }
    }
}
