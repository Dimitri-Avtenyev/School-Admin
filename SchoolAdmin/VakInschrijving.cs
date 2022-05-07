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
        private Student student;
        public Student Student {
            get {
                return student;
            }
        }
        private static List<VakInschrijving> alleVakInschrijvingen = new List<VakInschrijving>();
        public static ImmutableList<VakInschrijving> AlleVakInschrijvingen {
            get {
                return alleVakInschrijvingen.ToImmutableList<VakInschrijving>();
            }
        }
        public VakInschrijving(Student student, Cursus cursus, byte? resultaat) {
            if(student is null || cursus is null) {
                throw new ArgumentException("Inschrijving zonder student || vak kan niet.");
            } 
            //Student reeds ingeschreven
            foreach(VakInschrijving vak in VakInschrijving.AlleVakInschrijvingen) {
                if(vak.student.Equals(student)) {
                    throw new ArgumentException($"Student {vak.Student.Naam} is al ingeschreven voor {vak.Cursus.Titel}.");
                }
            }
            //Max 20 studenten per cursus
            if(cursus.Studenten.Count == 20) {
                throw new CapaciteitOverschredenException($"Maximum aantal studenten voor {cursus.Titel} is al bereikt, inschrijving niet meer mogelijk.");
            }
            this.cursus =  cursus;
            this.student = student;
            this.Resultaat = resultaat;
            alleVakInschrijvingen.Add(this);
        } 
        public static void VakInschrijvingToevoegen() {
            Console.WriteLine(Student.AlleStudenten.Count);
            Console.WriteLine("Welke student?");
            int counter = 1;
            foreach(var studentItem in Student.AlleStudenten) {
                Console.WriteLine($"{counter}.");
                Console.WriteLine(studentItem);
                counter++;
            }
            int studentKeuze = Convert.ToInt32(Console.ReadLine());
            //Test ArgumentException H16 
            if(studentKeuze == 0) {
                try {
                    new VakInschrijving(null, null, null);
                } catch(ArgumentException e) {
                    Console.WriteLine($"{e.Message}");
                }
                return;
            }
            //Test CapaciteitOverschrevenException -> opvulling cursus 20 inschrijvingen
            Cursus testCursus = new Cursus("TestCursus", 6);
            for(byte i = 0; i<20; i++) {
                Student testStudent = new Student("TestStudent", new DateTime(1990,1,1));
                new VakInschrijving(testStudent, testCursus, null);
            }
            Student student = Student.AlleStudenten[studentKeuze-1]; //userInput keuze 1 => index = 0
            student.ToString();
            Console.WriteLine("Welke cursus?");

            for(int i=0; i<Cursus.AlleCursussen.Count; i++) {
                Console.WriteLine($"{i+1}. {Cursus.AlleCursussen[i].Titel}");
            }
            int cursusKeuze = Convert.ToInt32(Console.ReadLine());
            Cursus cursus = null;
            try {
                cursus = Cursus.AlleCursussen[cursusKeuze-1];//userInput keuze 1 => index = 0
            } catch(CapaciteitOverschredenException e) {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Wil je een resultaat toekennen?");
            string resultaatKeuze = Console.ReadLine();
            switch(resultaatKeuze.ToLower()) {
                default: Console.WriteLine("Ongeldige keuze, antwoorden met 'ja/nee'");
                    break;
                case("ja"):
                    Console.WriteLine("Wat is het resultaat?");
                    byte resultaat = Convert.ToByte(Console.ReadLine());
                    try {
                        VakInschrijving vakInschrijving = new VakInschrijving(student, cursus, resultaat);
                    } catch(ArgumentException e) {
                        Console.WriteLine($"{e.Message}");
                    }
                    break;
                case("nee"):
                       try {
                        VakInschrijving vakInschrijving = new VakInschrijving(student, cursus, null);
                    } catch(ArgumentException e) {
                        Console.WriteLine($"{e.Message}");
                    }
                    break;
            }
        }
        public static void ToonInschrijvingsGegevens() {

            foreach(var inschrijving in VakInschrijving.AlleVakInschrijvingen) {
                Console.WriteLine($"{inschrijving.Student}\nIngeschreven voor {inschrijving.Cursus.Titel}");
            }
        }
    }
}