using FamilyTree.Entities;
using FamilyTree.Enums;
using System;

namespace FamilyTree.UnitTests.Fixtures
{
    public class FamilyTreeFixture : IDisposable
    {
        public Kingdom Kingdom;
        public Person Chit;
        public Person Yodhan;
        public Person Vila;
        public Person Dritha;
        public Person Jaya;
        public Person lika;
        public Person vich, tritha,vasa;
        public FamilyTreeFixture()
        {
            Kingdom = Initialize();
        }

        public void Dispose()
        {
            Kingdom = null;
        }

        private Kingdom Initialize()
        {
            var anga = new Person("Anga", Gender.Female, null, null);
            var shan = new Person("Shan", Gender.Male, null, null);
            anga.AddSpouse(shan);
            shan.AddSpouse(anga);

            Chit = new Person("Chit", Gender.Male, shan, anga);
            var amba = new Person("Amba", Gender.Female, null, null);
            Chit.AddSpouse(amba);
            amba.AddSpouse(Chit);
            Dritha = new Person("Dritha", Gender.Female, Chit, amba);
            tritha = new Person("Tritha", Gender.Female, Chit, amba);
            var vritha = new Person("Vritha", Gender.Male, Chit, amba);
            Jaya = new Person("Jaya", Gender.Male, null, null);
            Dritha.AddSpouse(Jaya);
            Jaya.AddSpouse(Dritha);
            Yodhan = new Person("Yodhan", Gender.Male, Jaya, Dritha);
            Dritha.AddChildren(Yodhan);
            amba.AddChildren(Dritha);
            amba.AddChildren(tritha);
            amba.AddChildren(vritha);

            var ish = new Person("Ish", Gender.Male, shan, anga);

            vich = new Person("Vich", Gender.Male, shan, anga);
            lika = new Person("Lika", Gender.Female, null, null);
            vich.AddSpouse(lika);
            lika.AddSpouse(vich);
            Vila = new Person("Vila", Gender.Female, vich, lika);
            var chika = new Person("Chika", Gender.Female, vich, lika);
            lika.AddChildren(chika);
            lika.AddChildren(Vila);

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
            vasa = new Person("Vasa", Gender.Male, asva, satvy);
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
            anga.AddChildren(Chit);
            anga.AddChildren(vich);
            anga.AddChildren(aras);
            anga.AddChildren(satya);

            return new Kingdom(shan, anga);
        }
    }
}
