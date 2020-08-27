using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class MaternalUncleHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private MaternalUncleHandler _handler;
        private FamilyTreeFixture _fixture;
        public MaternalUncleHandlerTests(FamilyTreeFixture fixture)
        {
            _handler = new MaternalUncleHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var yodhan = _fixture.Yodhan;
            var maternalUnce = _handler.Process(yodhan);
            Assert.NotNull(maternalUnce);
            Assert.True(maternalUnce.Count == 1);
            Assert.True((maternalUnce[0] == "Vritha"));
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var jaya = _fixture.Jaya;
            var maternalUnce = _handler.Process(jaya);
            Assert.NotNull(maternalUnce);
            Assert.True(maternalUnce.Count == 0);
        }
    }
}
