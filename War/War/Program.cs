using System;
using System.IO;
using War.Constants;
using War.Contracts;
using War.Entities;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = args[0];
                IRules rules = new Rules();
                using (var reader = new StreamReader(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] input = line.Split();
                        var lengaburu = new Planet(Kingdom.LENGABURU, LengaburuArmy.HORSES, LengaburuArmy.ELEPHANTS, LengaburuArmy.TANKS, LengaburuArmy.GUNS, rules);
                        int horses = int.Parse(input[1].Substring(0, input[1].Length - 1));
                        int elephant = int.Parse(input[2].Substring(0, input[2].Length - 1));
                        int tanks = int.Parse(input[3].Substring(0, input[3].Length - 2));
                        int guns = int.Parse(input[4].Substring(0, input[4].Length - 2));
                        var falconianArmy = new Army(horses, elephant, tanks, guns);
                        var result = lengaburu.Defends(falconianArmy);
                        Console.WriteLine(result);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred. Message:{ex.Message}");
            }
        }
    }
}
