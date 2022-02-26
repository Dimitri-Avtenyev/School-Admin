using System;

namespace SchoolAdmin 
{
    class CursusResultaat
    {
        private string naam;
        public byte resultaat;
        public CursusResultaat(string naam, byte resultaat) {
            this.naam = naam;
            this.Resultaat = resultaat;
        }
        public string Naam {
            get {
                return naam;
            }
        }
        public byte Resultaat {
            get {
                return resultaat;
            }
            set {
                if(value>=0 && value<=20) {
                    resultaat = value;
                } else {
                    Console.WriteLine("Resultaat moet tussen 0 en 20 zijn");
                }
            }
        }
    }
}