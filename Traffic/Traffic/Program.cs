using System;
using System.IO;

namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
            var kingShan = new KingShan();
            try
            {
                var fileName = args[0];
                using (var reader = new StreamReader(fileName))
                {
                    var line = reader.ReadLine();
                    string[] input = line.Split();
                    if (input.Length == 3)
                    {
                        var weather = input[0];
                        var orbitOneTrafficSpeed = input[1];
                        var orbitTwoTrafficSpeed = input[2];
                        string result = kingShan.DecideVehicle(weather, Convert.ToDouble(orbitOneTrafficSpeed), Convert.ToDouble(orbitTwoTrafficSpeed));
                        Console.WriteLine(result);
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
