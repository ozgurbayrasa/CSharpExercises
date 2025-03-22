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
            _randomMock = new Mock<Random>();
            _diceMock = new Mock<IDice>(_randomMock.Object);
            _userCommunicationMock = new Mock<IUserCommunication>();
            _cut = new GuessingGame(_diceMock.Object, _userCommunicationMock.Object);
        }




    }
}
