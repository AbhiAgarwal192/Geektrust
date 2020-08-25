using FamilyTree.Entities;
using System.Collections.Generic;

namespace FamilyTree.Handlers
{
    public interface IProcess
    {
        public List<string> Process(Person person);
    }
}
