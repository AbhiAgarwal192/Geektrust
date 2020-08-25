using FamilyTree.Entities;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public class SiblingsHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var siblings = new List<string>();
            if (person.Mother == null)
            {
                return siblings;
            }
            siblings = person.Brothers();
            var sisters = person.Sisters();
            
            int count = sisters.Count;
            for (int i = 0; i < count; i++)
            {
                siblings.Add(sisters[i]);
            }
            return siblings;
        }
    }
}
