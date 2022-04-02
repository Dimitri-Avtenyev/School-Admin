using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    class AdministratiefPersoneel : Personeel
    {
        private static List<AdministratiefPersoneel> alleAdministratiefPersoneel = new List<AdministratiefPersoneel>();
        public static ImmutableList<AdministratiefPersoneel> AlleAdministratiefPersoneel {
            get {
                return alleAdministratiefPersoneel.ToImmutableList();
            }
        }  
        public AdministratiefPersoneel(string naam, DateTime geboortedatum, Dictionary<string,byte> taken ):base(naam,geboortedatum,taken) {
            alleAdministratiefPersoneel.Add(this);
        }
        public override string GenereerNaamKaartje() {
            return $"{this.Naam} (ADMINISTRATIE)";
        }
        public override double BepaalWerkbelasting() {
            int totaal = 0;
            foreach(var taak in this.Taken) {
                totaal+=taak.Value;
            }
            return (double)totaal;
        }
        public override uint BerekenSalaris() {
            double salaris = 0;
            double ancienniteitstoeslag = Math.Floor((this.Ancienniteit/3.0));
            double tewerkstellingsbreuk = this.BepaalWerkbelasting()/40;

            salaris = (2000+75*ancienniteitstoeslag)*(tewerkstellingsbreuk);

            return (uint)salaris;
        }
        public static void DemonstreerAdministratiefPersoneel() {
            Dictionary<string, byte> taken = new Dictionary<string, byte>(){
                {"roostering",10}, {"correspondentie",10}, {"animatie",10}
                };
            AdministratiefPersoneel ahmed = new AdministratiefPersoneel("Ahmed Azzaoui", new DateTime(1988,2,4),taken);
            ahmed.Ancienniteit = 4;

            foreach(var personeel in AlleAdministratiefPersoneel) {
                Console.WriteLine(personeel.GenereerNaamKaartje());
                Console.WriteLine(("***".PadRight(personeel.GenereerNaamKaartje().Length,'*')));
                Console.WriteLine($"Werkbelasting: {ahmed.BepaalWerkbelasting()} uur");
                Console.WriteLine($"Salaris: {ahmed.BerekenSalaris()} euro");
            }
        }
    }
}