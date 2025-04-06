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

        
    }
}
