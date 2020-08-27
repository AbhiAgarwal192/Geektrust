using FamilyTree.Handlers;
using FamilyTree.UnitTests.Fixtures;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class PaternalAuntHandlerTests : IClassFixture<FamilyTreeFixture>
    {
        private PaternalAuntHandler _handler;
        private FamilyTreeFixture _fixture;
        public PaternalAuntHandlerTests(FamilyTreeFixture fixture)
        {
            _handler = new PaternalAuntHandler();
            _fixture = fixture;
        }

        [Fact]
        public void GivenRelationshipExists_ShouldReturnData()
        {
            var vasa = _fixture.vasa;
            var paternalAunt = _handler.Process(vasa);
            Assert.NotNull(paternalAunt);
            Assert.True(paternalAunt.Count == 1);
            Assert.True((paternalAunt[0] == "Atya"));
        }

        [Fact]
        public void GivenRelationshipDoesNotExists_ShouldReturnEmptyList()
        {
            var yodhan = _fixture.Yodhan;
            var paternalAunt = _handler.Process(yodhan);
            Assert.NotNull(paternalAunt);
            Assert.True(paternalAunt.Count == 0);
        }
    }
}
