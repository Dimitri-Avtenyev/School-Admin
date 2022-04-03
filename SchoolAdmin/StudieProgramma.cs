using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    class StudieProgramma
    {
        private string naam;
        public string Naam {
            get {
                return naam;
            }
            set {
                naam = value;
            }
        }
        private List<Cursus> cursussen = new List<Cursus>();
        public List<Cursus> Cursussen{
            get {
                return cursussen;
            }
            set {
                if(value is not null) {
                    cursussen = value;
                } else {
                    Console.WriteLine("Waarde mag niet null zijn");
                }   
            }
        }
        public StudieProgramma(string naam) {
            this.naam = naam;
        }
        public void ToonOverzicht() {
            Console.WriteLine(this.Naam);

            foreach(Cursus cursus in cursussen) {
                if(cursus is not null) {
                    Console.WriteLine($"\t{cursus.Titel}");
                }
            }      
        }
        public static void DemonstreerStudieProgramma() {
        Cursus communicatie = new Cursus("Communicatie");
        Cursus programmeren = new Cursus("Programmeren");
        Cursus databanken = new Cursus("Databanken", new List<Student>(7), 5);

        Cursus[] cursussenCollectie1 = { communicatie, programmeren, databanken };
        Cursus[] cursussenCollectie2 = { communicatie, programmeren, databanken };

        List<Cursus> cursussen1 = new List<Cursus>(cursussenCollectie1);
        List<Cursus> cursussen2 = new List<Cursus>(cursussenCollectie2);
        StudieProgramma programmerenProgramma = new StudieProgramma("Programmeren");
        StudieProgramma snbProgramma = new StudieProgramma("Systeem- en netwerkbeheer");
        programmerenProgramma.cursussen = cursussen1;
        snbProgramma.cursussen = cursussen2;
        // "Databanken" geschrapt uit het programma SNB -> "null"
        // SNB "Programmeren" hernoemd naar "Scripting"
        snbProgramma.cursussen[2] = null;
        snbProgramma.cursussen[1].Titel = "Scripting";
        programmerenProgramma.ToonOverzicht();
        snbProgramma.ToonOverzicht();
        }
    }
}