using FamilyTree.Entities;
using FamilyTree.Enums;
using FamilyTree.Utilities;
using System;
using System.IO;

namespace FamilyTree
{
    class Program
    {        
        static Kingdom Initialize()
        {
            var anga = new Person("Anga", Gender.Female, null, null);
            var shan = new Person("Shan", Gender.Male, null, null);
            anga.AddSpouse(shan);
            shan.AddSpouse(anga);

            var chit = new Person("Chit", Gender.Male, shan, anga);
            var amba = new Person("Amba", Gender.Female, null, null);
            chit.AddSpouse(amba);
            amba.AddSpouse(chit);
            var dritha = new Person("Dritha", Gender.Female, chit, amba);
            var tritha = new Person("Tritha", Gender.Female, chit, amba);
            var vritha = new Person("Vritha", Gender.Male, chit, amba);
            var jaya = new Person("Jaya", Gender.Female, null, null);
            dritha.AddSpouse(jaya);
            jaya.AddSpouse(dritha);
            var yodhan = new Person("Yodhan", Gender.Male, jaya, dritha);
            dritha.AddChildren(yodhan);
            amba.AddChildren(dritha);
            amba.AddChildren(tritha);
            amba.AddChildren(vritha);

            var ish = new Person("Ish", Gender.Male, shan, anga);

            var vich = new Person("Vich", Gender.Male, shan, anga);
            var lika = new Person("Lika", Gender.Female, null, null);
            vich.AddSpouse(lika);
            lika.AddSpouse(vich);
            var vila = new Person("Vila", Gender.Female, vich, lika);
            var chika = new Person("Chika", Gender.Female, vich, lika);
            lika.AddChildren(chika);
            lika.AddChildren(vila);

            var aras = new Person("Aras", Gender.Male, shan, anga);
            var chitra = new Person("Chitra", Gender.Female, null, null);
            aras.AddSpouse(chitra);
            chitra.AddSpouse(aras);

            var ahit = new Person("Ahit", Gender.Male, aras, chitra);
            var jnki = new Person("Jnki", Gender.Female, aras, chitra);
            var arit = new Person("Arit", Gender.Male, null, null);
            arit.AddSpouse(jnki);
            jnki.AddSpouse(arit);
            chitra.AddChildren(ahit);
            chitra.AddChildren(jnki);
            var laki = new Person("Laki", Gender.Male, arit, jnki);
            var lavnya = new Person("Lavnya", Gender.Female, arit, jnki);
            jnki.AddChildren(laki);
            jnki.AddChildren(lavnya);

            var satya = new Person("Satya", Gender.Female, shan, anga);
            var vyan = new Person("Vyan", Gender.Male, null, null);
            satya.AddSpouse(vyan);
            vyan.AddSpouse(satya);
            var atya = new Person("Atya", Gender.Female, vyan, satya);
            satya.AddChildren(atya);
            var asva = new Person("Asva", Gender.Male, vyan, satya);
            var satvy = new Person("Satvy", Gender.Female, null, null);
            satya.AddChildren(asva);
            asva.AddSpouse(satvy);
            satvy.AddSpouse(asva);
            var vasa = new Person("Vasa", Gender.Male, asva, satvy);
            satvy.AddChildren(vasa);
            var vyas = new Person("Vyas", Gender.Male, vyan, satya);
            var krpi = new Person("Krpi", Gender.Female, null, null);
            vyas.AddSpouse(krpi);
            krpi.AddSpouse(vyas);
            satya.AddChildren(vyas);
            var kriya = new Person("Kriya", Gender.Male, vyas, krpi);
            var krithi = new Person("Krithi", Gender.Female, vyas, krpi);
            krpi.AddChildren(kriya);
            krpi.AddChildren(krithi);

            anga.AddChildren(ish);
            anga.AddChildren(chit);
            anga.AddChildren(vich);
            anga.AddChildren(aras);
            anga.AddChildren(satya);

            return new Kingdom(shan, anga);
        }
        static void Main(string[] args)
        {
            var kingdom = Initialize();
            var operation = new Operation(kingdom);
            try
            {
                var fileName = args[0];
                using (var fileStream = new StreamReader(fileName))
                {
                    string line = fileStream.ReadLine();
                    while (line!=null)
                    {
                        string[] arr = line.Split();
                        if (arr.Length>=3)
                        {
                            var output = operation.Perform(arr);
                            Console.WriteLine(output);
                            line = fileStream.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred. Message:{ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
