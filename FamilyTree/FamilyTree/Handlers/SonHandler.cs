using FamilyTree.Entities;
using FamilyTree.Enums;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public class SonHandler : IProcess
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
                list = person.Son();
            }
            else
            {
                list = person.Spouse.Son();
            }
            return list;
        }
    }
}
