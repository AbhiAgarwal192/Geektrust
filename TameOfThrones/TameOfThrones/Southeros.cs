using System.Collections.Generic;
using TameOfThrones.Constants;
using TameOfThrones.Entities;

namespace TameOfThrones
{
    public class Southeros
    {
        private Dictionary<string, Kingdom> map;
        private int minimunAllies = 3;
        public Southeros()
        {
            this.map = new Dictionary<string, Kingdom>();
        }
        public Kingdom FindKingdom(string name)
        {
            switch (name)
            {
                case KingdomNames.SPACE:
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, new Kingdom(name, Emblems.Gorilla));
                    }
                    return map[name];
                case KingdomNames.LAND:
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, new Kingdom(name, Emblems.Panda));
                    }
                    return map[name];
                case KingdomNames.WATER:
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, new Kingdom(name, Emblems.Octopus));
                    }
                    return map[name];
                case KingdomNames.ICE:
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, new Kingdom(name, Emblems.Mammoth));
                    }
                    return map[name];
                case KingdomNames.AIR:
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, new Kingdom(name, Emblems.Owl));
                    }
                    return map[name];
                case KingdomNames.FIRE:
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, new Kingdom(name, Emblems.Dragon));
                    }
                    return map[name];
                default:
                    break;
            }
            return null;
        }
        public bool DecideRuler(Kingdom kingdom)
        {
            if (kingdom.Allies.Count<this.minimunAllies)
            {
                return false;
            }
            return true;
        }
    }
}
