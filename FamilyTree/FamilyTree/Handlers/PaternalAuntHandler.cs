using FamilyTree.Entities;
using FamilyTree.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree.Handlers
{
    public class PaternalAuntHandler : IProcess
    {
        public List<string> Process(Person person)
        {
            var list = new List<string>();
            if (person.Father == null)
            {
                return list;
            }
            list = person.Father.Sisters();
            return list;
        }
    }
}
