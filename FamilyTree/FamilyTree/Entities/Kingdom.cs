using FamilyTree.Enums;
using System.Collections.Generic;

namespace FamilyTree.Entities
{
    public class Kingdom
    {
        private Person _king;
        private Person _queen;
        public Person King { get { return _king; } }
        public Person Queen { get { return _queen; } }

        public Kingdom(Person king, Person queen)
        {
            this._king = king;
            this._queen = queen;
        }
        /// <summary>
        /// Returns null if child is not found
        /// </summary>
        /// <param name="name">Name of the child to search</param>
        /// <returns>Person</returns>
        public Person FindChild(string name)
        {
            var queue = new Queue<Person>();
            queue.Enqueue(this._queen);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node.Name.Equals(name))
                {
                    return node;
                }
                if (node.Spouse != null && node.Spouse.Name.Equals(name))
                {
                    return node.Spouse;
                }

                if (node.Gender == Gender.Female)
                {
                    int count = node.Children.Count;
                    for (int i = 0; i < count; i++)
                    {
                        queue.Enqueue(node.Children[i]);
                    }
                }
                else if(node.Spouse!=null && node.Spouse.Gender == Gender.Female)
                {
                    int count = node.Spouse.Children.Count;
                    for (int i = 0; i < count; i++)
                    {
                        queue.Enqueue(node.Spouse.Children[i]);
                    }
                }
            }
            return null;
        }
    }
}
