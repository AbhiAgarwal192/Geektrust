using FamilyTree.Entities;

namespace FamilyTree.Handlers
{
    public class RelationshipHandler
    {
        /// <summary>
        /// If a relationship is given which is not present in the list then return null.
        /// </summary>
        /// <param name="relationship"></param>
        /// <returns></returns>
        public IProcess GetHandler(string relationship)
        {
            switch (relationship)
            {
                case Relationship.Daughter:
                    return new DaughterHandler();
                case Relationship.Son:
                    return new SonHandler();
                case Relationship.Siblings:
                    return new SiblingsHandler();
                case Relationship.PaternalUncle:
                    return new PaternalUncleHandler();
                case Relationship.MaternalUncle:
                    return new MaternalUncleHandler();
                case Relationship.PaternalAunt:
                    return new PaternalAuntHandler();
                case Relationship.MaternalAunt:
                    return new MaternalAuntHandler();
                case Relationship.SisterInLaw:
                    return new SisterInLawHandler();
                case Relationship.BrotherInLaw:
                    return new BrotherInLawHandler();
            }

            return null;
        }
    }
}
