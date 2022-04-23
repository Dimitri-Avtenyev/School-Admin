using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin 
{
    class VakInschrijving
    {
        private Cursus cursus;
        public Cursus Cursus {
            get {
            return cursus;
            }
        }
        private byte? resultaat;
             public byte? Resultaat {
            get {
                return this.resultaat;
            } set {
                if(value is null || value>=0 && value<=20) {
                    this.resultaat = value;
                } else {
                    Console.WriteLine("Resultaat moet tussen 0 en 20 zijn");
                }
            }
        }
        private static List<VakInschrijving> alleVakInschrijvingen = new List<VakInschrijving>();
        public static ImmutableList<VakInschrijving> AlleVakInschrijvingen {
            get {
                return alleVakInschrijvingen.ToImmutableList();
            }
        }
        public VakInschrijving(Cursus cursus, byte? resultaat) {
            this.cursus =  cursus;
            this.Resultaat = resultaat;
            alleVakInschrijvingen.Add(this);
        } 
    }
}