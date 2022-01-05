using System;
using System.IO;

namespace TheLedger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ledger = new Ledger();
                var fileName = args[0];
                using (var reader = new StreamReader(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] input = line.Split();
                        ledger.Process(input);
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
