using FamilyTree.Entities;
using FamilyTree.Handlers;
using Xunit;

namespace FamilyTree.UnitTests.HandlerTests
{
    public class RelationshipHandlerTests
    {
        private RelationshipHandler _relationshipHandler; 
        public RelationshipHandlerTests()
        {
            _relationshipHandler = new RelationshipHandler();
        }

        [Fact]
        public void GivenRelationshipTypeAsSiblings_ShouldReturnSiblingsHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.Siblings);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsDaughter_ShouldReturnDaughterHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.Daughter);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsSon_ShouldReturnSonsHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.Son);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsPaternalAunt_ShouldReturnPaternalAuntHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.PaternalAunt);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsPaternalUncle_ShouldReturnPaternalUncleHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.PaternalUncle);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsMaternalAunt_ShouldReturnMaternalAuntHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.MaternalAunt);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsMaternalUncle_ShouldReturnMaternalUncleHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.MaternalUncle);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsSisterInLaw_ShouldReturnSisterInLawHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.SisterInLaw);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenRelationshipTypeAsBrotherInLaw_ShouldReturnBrotherInLawHandler()
        {
            var handler = _relationshipHandler.GetHandler(Relationship.BrotherInLaw);
            Assert.NotNull(handler);
        }

        [Fact]
        public void GivenAUnhandledRelationshipType_ShouldReturnNull()
        {
            var handler = _relationshipHandler.GetHandler("Grandfather");
            Assert.Null(handler);
        }
    }
}
