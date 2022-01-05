using System.IO;

namespace TameOfThrones
{
    public class GameEngine
    {
        public string Process(string fileName)
        {
            var southeros = new Southeros();
            using (var reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] input = line.Split(' ');
                    var senderKingdom = southeros.FindKingdom(input[0]);
                    var receiverKingdom = southeros.FindKingdom(input[1]);
                    var message = input[2];
                    senderKingdom.SendMessage(receiverKingdom,message);
                    line = reader.ReadLine();
                }
            }
            
            var ruler = southeros.DecideRuler();
            
        }

    }
}
