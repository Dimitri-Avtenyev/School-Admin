using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    abstract class Personeel : Persoon
    {
        private static List<Personeel> allePersoneel = new List<Personeel>();
        public static ImmutableList<Personeel> AllePersoneel {
            get {
                  List<Personeel> tempAllePersoneel = new List<Personeel>();
                    foreach(var persoon in Persoon.AllePersonen) {
                        if(persoon is Personeel) {
                            tempAllePersoneel.Add((Personeel)persoon);
                        }
                    }
                return tempAllePersoneel.ToImmutableList<Personeel>();
                
            }
        }
        private byte ancienniteit;
        public byte Ancienniteit {
            get {
                return this.ancienniteit;
            } set {
                if(value<50) {
                    this.ancienniteit = value;
                } else {
                    Console.WriteLine("Maximum ancienniteit bereikt! Auto-setting op 50");
                    this.ancienniteit = 50;
                }
            }
        } 
        private Dictionary<string, byte> taken = new Dictionary<string, byte>();
        public ImmutableDictionary<string, byte> Taken {
            get {
                Dictionary<string, byte> tempDictionary = new Dictionary<string, byte>();
                foreach(var record in taken) { 
                    if(record.Key is not null) {
                    tempDictionary.Add(record.Key, record.Value);
                    }
                }
                    return taken.ToImmutableDictionary<string, byte>();
            } 
        } 
       public Personeel(string naam, DateTime geboortedatum, Dictionary<string, byte> taken):base(naam, geboortedatum) {
           this.taken = taken;
            if (!(taken is null)) {
            foreach(var record in taken) {
                this.taken.Add(record.Key,record.Value);
            }
        }
       }
       public abstract uint BerekenSalaris();
    }
 
}