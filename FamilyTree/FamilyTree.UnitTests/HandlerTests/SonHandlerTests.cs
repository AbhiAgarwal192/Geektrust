using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class SonHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private SonHandler _sonHandler;
        private FamilyTreeFixture _fixture;
        public SonHandlerTests(FamilyTreeFixture fixture)
        {
            _sonHandler = new SonHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExistsAndAccessingThroughMother_ShouldReturnData()
        {
            var dritha = _fixture.Dritha;
            var son = _sonHandler.Process(dritha);
            Assert.NotNull(son);
            Assert.True(son.Count == 1);
            Assert.Equal("Yodhan", son[0]);
        }

        [Fact]
        public void GivenRelationshipExistsAndAccessingThroughFather_ShouldReturnData()
        {
            var jaya = _fixture.Jaya;
            var son = _sonHandler.Process(jaya);
            Assert.NotNull(son);
            Assert.True(son.Count == 1);
            Assert.Equal("Yodhan", son[0]);
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var yodhan = _fixture.Yodhan;
            var son = _sonHandler.Process(yodhan);
            Assert.NotNull(son);
            Assert.True(son.Count == 0);
        }
    }
}
