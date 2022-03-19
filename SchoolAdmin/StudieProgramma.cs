using System;

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
        private Cursus[] cursussen;
        public Cursus[] Cursussen{
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
            this.Cursussen = new Cursus[3];
        }
        public void ToonOverzicht() {
            Console.WriteLine(this.Naam);
            if(this.cursussen is null) {
                Console.WriteLine("Er zijn geen cursussen aanwezig.");
            }
            foreach(Cursus cursus in cursussen) {
                if(cursus is not null) {
                    Console.WriteLine($"\t{cursus.Titel}");
                }
            }
            
        }
        public static void DemonstreerStudieProgramma() {
        Cursus communicatie = new Cursus("Communicatie");
        Cursus programmeren = new Cursus("Programmeren");
        Cursus databanken = new Cursus("Databanken", new Student[7], 5);
        Cursus[] cursussen1 = { communicatie, programmeren, databanken };
        Cursus[] cursussen2 = { communicatie, programmeren, databanken };
        StudieProgramma programmerenProgramma = new StudieProgramma("Programmeren");
        StudieProgramma snbProgramma = new StudieProgramma("Systeem- en netwerkbeheer");
        programmerenProgramma.cursussen = cursussen1;
        snbProgramma.cursussen = cursussen2;
        // later wordt Databanken geschrapt uit het programma SNB
        // voor SNB wordt bovendien Programmeren hernoemd naar Scripting
        snbProgramma.cursussen[2] = null;
        snbProgramma.cursussen[1].Titel = "Scripting";
        programmerenProgramma.ToonOverzicht();
        snbProgramma.ToonOverzicht();
        }
    }
}