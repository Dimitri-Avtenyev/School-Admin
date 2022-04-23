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
            } set {
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
        public byte Leeftijd {
            get {
                DateTime nu = DateTime.Now;
                
                return (byte)(nu.Year - this.Geboortedatum.Year);
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

        public override bool Equals(Object obj) {
            if(obj is null) {
                return false;
            } 
            bool gelijk; 
            if(GetType() != obj.GetType()) {
                gelijk = false;
            } else {
                Persoon temp = (Persoon)obj;
                if(Id == temp.Id) {
                    gelijk = true;
                } else {
                    gelijk = false;
                }
            }
            return gelijk;
        }
        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
        public override string ToString() {
            string persoonFunctie = "";
            if(this.GetType().Name == "AdministratiesPersoneel") {
                persoonFunctie = "administratief personeel";
            } else if(this.GetType().Name == "Lector") {
                persoonFunctie = "lector";
            } else if(this.GetType().Name == "Student") {
                persoonFunctie = "student";
            }
            string naamKaartje = $"Persoon\n-------\nNaam: {this.Naam}\nLeeftijd: {this.Leeftijd}\nMeerbepaald, {persoonFunctie}";
            return naamKaartje.ToString();
        }
    }

}