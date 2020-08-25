using System;
using System.Collections.Generic;
using TameOfThrones.Entities;

namespace TameOfThrones
{
    public class Formatter
    {
        public string Format(List<Kingdom> ally)
        {
            string allies = "";
            int count = ally.Count;
            for (int i = 0; i < count; i++)
            {
                allies = $"{allies} {ally[i].Name}";
            }
            return allies.Trim();
        }
    }
}
