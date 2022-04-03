using System;
using System.Collections.Generic;
using System.Collections.Immutable;


namespace SchoolAdmin
{
    class Lector : Personeel
    {
        private static List<Lector> alleLectoren = new List<Lector>();
        public static ImmutableList<Lector> AlleLectoren {
            get {
                return alleLectoren.ToImmutableList();
            }
        }
        private Dictionary<Cursus, double> cursussen = new Dictionary<Cursus, double>();
        public Lector(string naam, DateTime geboortedatum, Dictionary<string, byte> taken):base(naam, geboortedatum, taken) {
            alleLectoren.Add(this);
        }
        public override string GenereerNaamKaartje() {
            string naamKaartje = $"{this.Naam} (LECTOR)\nLector voor:\n";
            foreach(var cursus in cursussen) {
                naamKaartje+=$"{cursus.Key.Titel}\n";
            }
            return naamKaartje;
        }
        public override double BepaalWerkbelasting() {
            double totaal = 0;
            foreach(var cursus in this.cursussen) {
                totaal+=cursus.Value;
            }
            return totaal;
        }
        public override uint BerekenSalaris() {
            double salaris = 0;
            double ancienniteitstoeslag = Math.Floor((this.Ancienniteit/4.0));
            double tewerkstellingsbreuk = this.BepaalWerkbelasting()/40;

            salaris = (2200+120*ancienniteitstoeslag)*(tewerkstellingsbreuk);

        return (uint)salaris;
        }
        public static void DemonstreerLectoren() {
            Cursus economie = new Cursus("Economie");
            Cursus statistiek = new Cursus("Statistiek");
            Cursus analytischeMeetkunde = new Cursus("Analytische Meetkunde");
            Lector anna = new Lector("Anna Bolzano", new DateTime(1975,6,12),new Dictionary<string, byte>());
            anna.Ancienniteit = 9;
            anna.cursussen.Add(economie,3);
            anna.cursussen.Add(statistiek,3);
            anna.cursussen.Add(analytischeMeetkunde,4);
            
            //Intermezzo controle AllePersoneel && AlleLectoren
            Console.WriteLine("Personeel\n"+"-".PadRight("Personeel".Length,'-'));
            foreach(var personeel in Personeel.AllePersoneel) {
               Console.WriteLine(personeel.GenereerNaamKaartje());
            }
            Console.WriteLine("Lectoren");
            foreach(var lector in Lector.AlleLectoren) {
                Console.WriteLine(lector.GenereerNaamKaartje());
                Console.WriteLine($"Werkbelasting: {anna.BepaalWerkbelasting()} uur");
                Console.WriteLine($"Salaris: {anna.BerekenSalaris()} euro");
            }
            Console.WriteLine($"Aantal personeel: {AllePersoneel.Count} // Aantal lectoren: {AlleLectoren.Count}");
        }
    }
}