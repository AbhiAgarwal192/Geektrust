using FamilyTree.Entities;
using FamilyTree.Enums;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public class DaughterHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var list = new List<string>();
            if (!person.IsMarried())
            {
                return list;
            }
            if (person.Gender == Gender.Female)
            {
                list = person.Daughter();
            }
            else
            {
                list = person.Spouse.Daughter();
            }
            return list;
        }
    }
}
