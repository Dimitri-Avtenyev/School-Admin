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
                Console.WriteLine(counter);
                Console.WriteLine(studentItem);
                counter++;
            }
            int studentKeuze = Convert.ToInt32(Console.ReadLine());
            Student student = Student.AlleStudenten[studentKeuze-1]; //userInput keuze 1 => index = 0
            student.ToString();
            Console.WriteLine("Welke cursus?");

            for(int i=0; i<Cursus.AlleCursussen.Count; i++) {
                Console.WriteLine($"{i+1}. {Cursus.AlleCursussen[i].Titel}");
            }
            int cursusKeuze = Convert.ToInt32(Console.ReadLine());
            Cursus cursus = Cursus.AlleCursussen[cursusKeuze-1];//userInput keuze 1 => index = 0
            Console.WriteLine("Wil je een resultaat toekennen?");
            string resultaatKeuze = Console.ReadLine();
            switch(resultaatKeuze.ToLower()) {
                default: Console.WriteLine("Ongeldige keuze, antwoorden met 'ja/nee'");
                    break;
                case("ja"):
                    Console.WriteLine("Wat is het resultaat?");
                    byte resultaat = Convert.ToByte(Console.ReadLine());
                    VakInschrijving vakInschrijving = new VakInschrijving(student, cursus, resultaat);
                    break;
                case("nee"):
                    vakInschrijving = new VakInschrijving(student, cursus, null);
                    break;
            }
        }
        public static void ToonInschrijvingsGegevens() {

            foreach(var inschrijving in AlleVakInschrijvingen) {
                Console.WriteLine($"{inschrijving.Student}\nIngeschreven voor {inschrijving.Cursus.Titel}");
            }
        }
    }
}