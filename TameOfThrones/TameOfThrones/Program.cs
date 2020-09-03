using System;
using System.IO;
using TameOfThrones.Constants;

namespace TameOfThrones
{
    class Program
    {
        private static string NONE = "NONE";
        public static void Main(string[] args)
        {
            var southeros = new Southeros();
            var spaceKingdom = southeros.FindKingdom(KingdomNames.SPACE);
            var formatter = new Formatter();
            try
            {
                var fileName = args[0];
                using (var reader = new StreamReader(fileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] input = line.Split();
                        if (input.Length==2)
                        {
                            var kingdom = southeros.FindKingdom(input[0]);
                            spaceKingdom.SendMessage(kingdom, input[1]);
                        }
                        line = reader.ReadLine();
                    }
                }
                bool isGorillaKingRuler = southeros.DecideRuler(spaceKingdom);
                if (!isGorillaKingRuler)
                {
                    Console.WriteLine(NONE);
                }
                else
                {
                    var allies = spaceKingdom.Allies;
                    Console.WriteLine($"{spaceKingdom.Name} {formatter.Format(allies)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred. Message: {ex.Message}");
            }
        }
    }
}
