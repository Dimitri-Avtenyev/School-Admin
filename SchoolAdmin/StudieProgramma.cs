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
            } set {
                naam = value;
            }
        }
        private Dictionary<Cursus, byte> cursussen = new Dictionary<Cursus, byte>();
        public Dictionary<Cursus, byte> Cursussen{
            get {
                return cursussen;
            } set {
                if(value is not null) {
                    cursussen = value;
                } else {
                    Console.WriteLine("Waarde mag niet null zijn");
                }   
            }
        }
        public StudieProgramma(string naam) {
            this.Naam = naam;
        }
        public void ToonOverzicht() {
            Console.WriteLine(this.Naam);

            foreach(var cursus in cursussen) {
                if(cursus.Key is not null) {
                    Console.WriteLine($"\t{cursus.Key.Titel.PadRight(30)} Semester: {cursus.Value}");
                }
            }      
        }
        public static void DemonstreerStudieProgramma() {
        Cursus communicatie = new Cursus("Communicatie");
        Cursus programmeren = new Cursus("Programmeren");
        Cursus databanken = new Cursus("Databanken", 5);

        Dictionary<Cursus, byte> cursussenVoorProgrammeren = new Dictionary<Cursus, byte>() {
            {communicatie, 1}, {programmeren, 1}, {databanken, 1}
        };
        Dictionary<Cursus, byte> cursussenVoorSnb = new Dictionary<Cursus, byte>() {
            {communicatie, 2}, {programmeren, 1}, {databanken, 1}
        };
        StudieProgramma programmerenProgramma = new StudieProgramma("Programmeren");
        StudieProgramma snbProgramma = new StudieProgramma("Systeem- en netwerkbeheer");
        programmerenProgramma.cursussen = cursussenVoorProgrammeren;
        snbProgramma.cursussen = cursussenVoorSnb;
    // oefening
        // "Databanken" geschrapt uit het programma SNB
        // SNB "Programmeren" hernoemd naar "Scripting" -> vervanging 
        cursussenVoorSnb.Remove(databanken);
        cursussenVoorSnb.Remove(programmeren);
        cursussenVoorSnb.Add(new Cursus("Scripting"), 1);
    
        programmerenProgramma.ToonOverzicht();
        snbProgramma.ToonOverzicht();
        }
    }
}