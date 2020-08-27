using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class MaternalAuntHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private MaternalAuntHandler _handler;
        private FamilyTreeFixture _fixture;
        public MaternalAuntHandlerTests(FamilyTreeFixture fixture)
        {
            _handler = new MaternalAuntHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var yodhan = _fixture.Yodhan;
            var maternalaunt = _handler.Process(yodhan);
            Assert.NotNull(maternalaunt);
            Assert.True(maternalaunt.Count == 1);
            Assert.True((maternalaunt[0] == "Tritha"));
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var vila = _fixture.Vila;
            var maternalAunt = _handler.Process(vila);
            Assert.NotNull(maternalAunt);
            Assert.True(maternalAunt.Count == 0);
        }
    }
}
