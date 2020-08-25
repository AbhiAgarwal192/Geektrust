using FamilyTree.Entities;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public class PaternalUncleHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var list = new List<string>();
            if (person.Father == null)
            {
                return list;
            }
            list = person.Father.Brothers();
            return list;
        }
    }
}
