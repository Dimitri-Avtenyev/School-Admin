using System;

namespace SchoolAdmin 
{
    class VakInschrijving
    {
        private string naam;
        private byte? resultaat;
        public VakInschrijving(string naam, byte? resultaat) {
            this.naam = naam;
            this.Resultaat = resultaat;
        }
        public string Naam {
            get {
                return this.naam;
            }
        }
        public byte? Resultaat {
            get {
                return this.resultaat;
            }
            set {
                if(value is null || value>=0 && value<=20) {
                    this.resultaat = value;
                } else {
                    Console.WriteLine("Resultaat moet tussen 0 en 20 zijn");
                }
            }
        }
    }
}