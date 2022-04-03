using System;

namespace SchoolAdmin 
{
    class VakInschrijving
    {
        private Cursus cursus;
        private byte? resultaat;
        public VakInschrijving(Cursus cursus, byte? resultaat) {
            this.cursus =  cursus;
            this.Resultaat = resultaat;
        }
        public string Naam {
            get {
                return this.cursus.Titel;
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