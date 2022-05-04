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
                List<AdministratiefPersoneel> tempAlleAdministratiefPersoneel = new List<AdministratiefPersoneel>();
                foreach(var persoon in Persoon.AllePersonen) {
                    if(persoon is AdministratiefPersoneel) {
                        tempAlleAdministratiefPersoneel.Add((AdministratiefPersoneel)persoon);
                    }
                }
                return tempAlleAdministratiefPersoneel.ToImmutableList<AdministratiefPersoneel>();
            }
        }  
        public AdministratiefPersoneel(string naam, DateTime geboortedatum, Dictionary<string,byte> taken ):base(naam,geboortedatum,taken) {
          
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
            //ahmed.Ancienniteit = 60; 

            //Intermezzo controle AllePersoneel && AlleAdministratiefPersoneel
            Console.WriteLine(">>>Personeel<<<\n"+"-".PadRight(">>>Personeel<<<".Length,'-'));
            foreach(var personeel in Personeel.AllePersoneel) {
                Console.WriteLine(personeel.GenereerNaamKaartje());
            }
            Console.WriteLine("-".PadRight(">>>Personeel<<<".Length,'-'));
            Console.WriteLine(">>>Administratief personeel<<<\n"+"-".PadRight(">>>Administratief personeel<<<".Length,'-'));
            foreach(var personeel in AlleAdministratiefPersoneel) {
                Console.WriteLine(personeel.GenereerNaamKaartje());
                Console.WriteLine($"Werkbelasting: {ahmed.BepaalWerkbelasting()} uur");
                Console.WriteLine($"Salaris: {ahmed.BerekenSalaris()} euro");
            }
            Console.WriteLine("-".PadRight(">>>Administratief personeel<<<".Length,'-'));
        }
    }
}