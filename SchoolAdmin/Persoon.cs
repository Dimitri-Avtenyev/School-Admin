using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    abstract class Persoon
    {
        private string naam;
        public string Naam {
            get {
                return this.naam;
            }
            set {
                this.naam = value;
            }
        }
        private static uint maxId = 1;
        private uint id;
        public uint Id {
            get {
                return this.id;
            }
        }
        private DateTime geboortedatum;
        public DateTime Geboortedatum {
            get {
                return this.geboortedatum;
            }
        }
        public Persoon(string naam, DateTime geboortedatum) {
            this.Naam = naam;
            this.geboortedatum = geboortedatum;
            allePersonen.Add(this);
            this.id = maxId;
            maxId++;
        }
        private static List<Persoon> allePersonen = new List<Persoon>();
        public static ImmutableList<Persoon> AllePersonen {
            get {
                return allePersonen.ToImmutableList();
            }
        }
        public abstract string GenereerNaamKaartje();
        public abstract double BepaalWerkbelasting();
         
    }
}