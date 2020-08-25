using System;
using System.Collections.Generic;

namespace TameOfThrones.Entities
{
    public class Message
    {
        public bool Verify(string message,string emblem)
        {
            var dictionary = new Dictionary<char, int>();
            int secretKey = emblem.Length;
            var length = message.Length;
            for (int i = 0; i < length; i++)
            {
                int characterAscii = message[i] - secretKey;
                if (characterAscii < 'A')
                {
                    var diff = 'A' - characterAscii;
                    characterAscii = 'Z' - diff + 1;
                }
                var actualCharacter = Convert.ToChar(characterAscii);
                if (dictionary.ContainsKey(actualCharacter))
                {
                    dictionary[actualCharacter] = dictionary[actualCharacter] + 1;
                }
                else
                {
                    dictionary.Add(actualCharacter, 1);
                }
            }
            length = emblem.Length;
            bool isAlly = true;
            for (int i = 0; i < length; i++)
            {
                if (dictionary.ContainsKey(emblem[i]) && dictionary[emblem[i]] > 0)
                {
                    dictionary[emblem[i]] = dictionary[emblem[i]] - 1;
                }
                else
                {
                    isAlly = false;
                    break;
                }
            }
            return isAlly;
        }
    }
}
