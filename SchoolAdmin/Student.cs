using System;
using System.Collections.Generic;
using System.Collections.Immutable;


namespace SchoolAdmin
{
    class Student : Persoon
    {
        public static ImmutableList<Student> AlleStudenten {
            get {
                List<Student> tempAlleStudenten = new List<Student>();
                foreach(var persoon in Persoon.AllePersonen) {
                    if(persoon is Student) {
                        tempAlleStudenten.Add((Student)persoon);
                    }
                }
                return tempAlleStudenten.ToImmutableList<Student>();
            }
        }
        private Dictionary<DateTime, string> dossier;
        public ImmutableDictionary<DateTime, string> Dossier {
            get {
                return this.dossier.ToImmutableDictionary<DateTime, string>();
            }
        } 
        public Student(string naam, DateTime geboorteDatum):base(naam,geboorteDatum) {
            this.dossier = new Dictionary<DateTime, string>();
        }
        public ImmutableList<VakInschrijving> VakInschrijvingen {
            get {
                List<VakInschrijving> tempVakscrijvingen = new List<VakInschrijving>();
                foreach(var vakinschrijving in VakInschrijving.AlleVakInschrijvingen) {
                    if(this.Equals(vakinschrijving.Student)) {
                        tempVakscrijvingen.Add(vakinschrijving);
                    } 
                }
                return tempVakscrijvingen.ToImmutableList<VakInschrijving>();
            }
        }
        public ImmutableList<Cursus> Cursussen {
            get {
                List<Cursus> tempCursussen = new List<Cursus>();
                foreach(var vak in VakInschrijvingen) {
                    tempCursussen.Add(vak.Cursus);
                }
                return tempCursussen.ToImmutableList<Cursus>();
            }
        }
        public override string GenereerNaamKaartje() {
            return $"{this.Naam} (STUDENT)";
        }
        public override double BepaalWerkbelasting() {
            double totaal = 0;
            foreach (var vakInschrijving in VakInschrijvingen) {
                if(vakInschrijving is not null) {
                    totaal +=10;
                }
            }
            return totaal;
        }
        public void RegistreerVakInschrijving(Cursus cursus, byte? cijfer) {

            new VakInschrijving(this, cursus, cijfer);
           
        }
        //older method (H10), before lists/foreach
        public void Kwoteer(byte cursusindex,byte behaaldCijfer) {
            if(behaaldCijfer<0 || behaaldCijfer >20 || cursusindex>VakInschrijvingen.Count || VakInschrijvingen[cursusindex] is null) {
                Console.WriteLine("Ongeldig cijfer!");
            } else {
                this.VakInschrijvingen[cursusindex].Resultaat = behaaldCijfer;
            }
            
        }
        public double Gemiddelde() {
            double gemiddelde = 0.0;
            double som = 0;
            byte counter = 0;
            foreach(var vakInschrijving in VakInschrijvingen) {
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
            foreach(var vakinschrijving in VakInschrijvingen) {
                if(vakinschrijving is not null) {
                    Console.WriteLine($"{vakinschrijving.Cursus.Titel}:".PadRight(20)+$"{vakinschrijving.Resultaat}"); 
                }
            }
            Console.WriteLine($"Gemiddelde:".PadRight(20)+$"{this.Gemiddelde():F1}\n");
        }
        public static void ToonStudenten() {
            Console.WriteLine("Toon studenten in:");
            Console.WriteLine("1. Stijgende alfabetische volgorde");
            Console.WriteLine("2. Dalende alfabetische volgorde");
            int keuze = 0;
            try {
                keuze = Convert.ToInt32(Console.ReadLine());
            } catch(ArgumentException) {
                Console.WriteLine("Keuze moet een getal zijn");
            }
            
            IComparer<Student> comparer = null;
            switch(keuze) {
                case(1):
                comparer = new StudentenVolgensNaamComparerOplopend();
                    break;
                case(2):
                comparer = new StudentenVolgensNaamComparerAflopend();
                    break;
                default: Console.WriteLine("Ongeldige keuze!");
                    break;
            }

            ImmutableList<Student> alleStudentenGesorteerd = AlleStudenten.Sort(comparer);
            foreach (Student student in alleStudentenGesorteerd) {
                Console.WriteLine(student.ToString());
            }

        }
        public static Student StudentUitTekstFormaat(string cvsWaarde) {
            //input vb: Naam;dd;mm;yyy;cursus;cijfer; ...cursus;cijfer
            string[] cvsWaardes = cvsWaarde.Split(";");
            int day = Convert.ToInt32(cvsWaardes[1]);
            int month = Convert.ToInt32(cvsWaardes[2]);
            int year = Convert.ToInt32(cvsWaardes[3]);
            string naam = cvsWaardes[0];

            Student student = new Student(naam, new DateTime(year,month,day));;

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
            
            Student student1 = new Student("Dimitri Avtenyev", new DateTime(1990, 12, 2)); 
            Cursus programmeren = new Cursus("Programmeren");
            Cursus webontwikkeling = new Cursus("Webontwikkeling");
            Cursus databanken = new Cursus("Databanken");
            Cursus theForce = new Cursus("The Force");
                try {
                Cursus testDuplicateException = new Cursus("Programmeren");
            } catch(DuplicateDataException e) {
                Console.WriteLine($"Duplicaat: {e}");
            }
            
            student1.RegistreerVakInschrijving(programmeren, 17);
            
            //Test met dossier
            // student1.dossier.Add(DateTime.Now, "dossier item test");
            
            // foreach(var item in student1.dossier) {
            //     Console.WriteLine(item);
            // }

            //student1.Kwoteer(0,17);
            student1.RegistreerVakInschrijving(webontwikkeling, 18);
            //student1.Kwoteer(1, 18);
            student1.RegistreerVakInschrijving(databanken, 16);
            //student1.Kwoteer(2, 16);
            student1.ToonOverzicht();

            Student student2 = new Student("Kylo Ren",new DateTime(1989, 1, 1));
            student2.RegistreerVakInschrijving(theForce, 19);
            //student2.Kwoteer(0, 19);
            student2.RegistreerVakInschrijving(programmeren, 13);
            //student2.Kwoteer(1, 13);
            student2.RegistreerVakInschrijving(databanken, 9);
            //student2.Kwoteer(2, 9);
            student2.ToonOverzicht();

            //Test Vakinschrijvingen
            // foreach(var vak in student1.VakInschrijvingen) {
            //     Console.WriteLine($"print van vakinschrijvingen {student1.Naam}");
            //     Console.WriteLine(vak.Cursus.Titel);
            // }
            
        }
        public static void DemonstreerStudentUitTekstFormaat() {
            Console.WriteLine("Geef de tekstvoorstelling van 1 student in CSV-formaat: ");
            string userInput = Console.ReadLine();
            StudentUitTekstFormaat(userInput).ToonOverzicht();
        }
        public static void StudentToevoegen() {
            Console.WriteLine("Naam van de student?");
            string naam = Console.ReadLine();
            Console.WriteLine("Geboortedatum van de student? (dd/MM/yyyy)");
            string geboorteDatum = Console.ReadLine();
            new Student(naam, DateTime.Parse(geboorteDatum));
        }


    }
}