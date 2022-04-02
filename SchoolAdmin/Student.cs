using System;
using System.Collections.Generic;
using System.Collections.Immutable;


namespace SchoolAdmin
{
    class Student
    {
        public string Naam;
        public DateTime Geboortedatum;
        public uint Studentennummer;
        private List<VakInschrijving> vakInschrijvingen = new List<VakInschrijving>();
        public static uint StudentenTeller = 1;
        private static List<Student> alleStudenten = new List<Student>();
        
        public static ImmutableList<Student> AlleStudenten {
            get {
                return alleStudenten.ToImmutableList();
            }
        }
        
        public Student(string naam, DateTime geboorteDatum) {
            this.Naam = naam;
            this.Geboortedatum = geboorteDatum;
            StudentenTeller++;
            alleStudenten.Add(this);
        }
        public Student() {
            StudentenTeller++;
            alleStudenten.Add(this);
        }
        public string GenereerNaamKaartje() {
            return $"{this.Naam} (STUDENT)";
        }
        public byte BepaalWerkbelasting() {
            byte totaal = 0;
            foreach (var vakInschrijving in vakInschrijvingen) {
                if(vakInschrijving is not null) {
                    totaal +=10;
                }
            }
            return totaal;
        }
        public void RegistreerVakInschrijving(Cursus cursus, byte? cijfer) {

            VakInschrijving nieuwVakInschrijving = new VakInschrijving(cursus, cijfer);
            vakInschrijvingen.Add(nieuwVakInschrijving);
        }
        //older method (H10), before lists/foreach
        public void Kwoteer(byte cursusindex,byte behaaldCijfer) {
            if(behaaldCijfer<0 || behaaldCijfer >20 || cursusindex>vakInschrijvingen.Count || vakInschrijvingen[cursusindex] is null) {
                Console.WriteLine("Ongeldig cijfer!");
            } else {
                this.vakInschrijvingen[cursusindex].Resultaat = behaaldCijfer;
            }
            
        }
        public double Gemiddelde() {
            double gemiddelde = 0.0;
            double som = 0;
            byte counter = 0;
            foreach(var vakInschrijving in vakInschrijvingen) {
                if(vakInschrijving is not null) {
                    som += (byte)vakInschrijving.Resultaat;
                    counter++;
                }
            }
            gemiddelde = som/counter;
            return gemiddelde;
        }
        public void ToonOverzicht() {
            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine($"{this.GenereerNaamKaartje()}, {currentDateTime.Year - this.Geboortedatum.Year-1} jaar");
            Console.WriteLine("\nCijferrapport:\n"+$"{"*******".PadRight("Cijferrapport:".Length,'*')}\n");
            foreach(var vakinschrijving in vakInschrijvingen) {
                if(vakinschrijving is not null) {
                    Console.WriteLine($"{vakinschrijving.Naam}:".PadRight(20)+$"{vakinschrijving.Resultaat}"); 
                }
            }
            Console.WriteLine($"Gemiddelde:".PadRight(20)+$"{this.Gemiddelde():F1}\n");
        }
        public static Student StudentUitTekstFormaat(string cvsWaarde) {

            string[] cvsWaardes = cvsWaarde.Split(";");
            Student student = new Student();
            int day = Convert.ToInt32(cvsWaardes[1]);
            int month = Convert.ToInt32(cvsWaardes[2]);
            int year = Convert.ToInt32(cvsWaardes[3]);
            student.Naam = cvsWaardes[0];
            student.Geboortedatum = new DateTime(year, month, day);
            student.Studentennummer = StudentenTeller;
            Student.StudentenTeller++;

            if(cvsWaardes.Length > 4) {
                for(int i=4; i<cvsWaardes.Length; i+=2) {
                    string cursusNaam = cvsWaardes[i]; 
                    Cursus cursus = new Cursus(cursusNaam);
                    byte cijfer = Convert.ToByte(cvsWaardes[i+1]);
                    student.RegistreerVakInschrijving(cursus, cijfer);
                }
            }           
            return student;
        }
        public static void DemonstreerStudent() {

            Student.StudentenTeller = 1;
            Student student1 = new Student(); //of constructor met naam,...
           
            student1.Naam = "Dimitri Avtenyev"; //demo met properties'set' ipv via constructor
            student1.Geboortedatum = new DateTime(1990, 12, 2);
            student1.Studentennummer = Student.StudentenTeller;
            Cursus programmeren = new Cursus("Programmeren");
            Cursus webontwikkeling = new Cursus("Programmeren");
            Cursus databanken = new Cursus("Databanken");
            Cursus theForce = new Cursus("The Force");
            student1.RegistreerVakInschrijving(programmeren, 17);
            //student1.Kwoteer(0,17);
            student1.RegistreerVakInschrijving(webontwikkeling, 18);
            //student1.Kwoteer(1, 18);
            student1.RegistreerVakInschrijving(databanken, 16);
            //student1.Kwoteer(2, 16);
            student1.ToonOverzicht();

            Student student2 = new Student("Kylo Ren",new DateTime(1989, 1, 1));
            student2.Studentennummer = Student.StudentenTeller;
            student2.RegistreerVakInschrijving(theForce, 19);
            //student2.Kwoteer(0, 19);
            student2.RegistreerVakInschrijving(programmeren, 13);
            //student2.Kwoteer(1, 13);
            student2.RegistreerVakInschrijving(databanken, 9);
            //student2.Kwoteer(2, 9);
            student2.ToonOverzicht();
        }
        public static void DemonstreerStudentUitTekstFormaat() {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat: ");
            string userInput = Console.ReadLine();
            StudentUitTekstFormaat(userInput).ToonOverzicht();
        }

    }
}