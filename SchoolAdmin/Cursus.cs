using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    class Cursus
    {
        public string Titel;
        private static int maxId = 1;
        private static List<Cursus> alleCursussen = new List<Cursus>();
        public static ImmutableList<Cursus> AlleCursussen {
            get {
            return alleCursussen.ToImmutableList<Cursus>();
            }
        }
        private byte studiepunten;
        public byte Studiepunten {
            get {
                return studiepunten;
            } private set {
                studiepunten = value;
            }
        }
        private int id;
        public int Id {
            get {
                return id;
            }
        }
        public int MaxId {
            get {
                return maxId;
            } set {
                maxId = value;
            }
        }
        public ImmutableList<Student> Studenten {
            get {
                List<Student> tempStudenten = new List<Student>();
                foreach(var vakinschrijving in VakInschrijvingen) {
                    tempStudenten.Add(vakinschrijving.Student);  
                }   
                return tempStudenten.ToImmutableList<Student>();
            }
        }
        public ImmutableList<VakInschrijving> VakInschrijvingen {
            get {
                List<VakInschrijving> tempVakinschrijvingen = new List<VakInschrijving>();
                foreach(var vak in VakInschrijving.AlleVakInschrijvingen) {
                    if(vak.Cursus.Equals(this)) {
                        tempVakinschrijvingen.Add(vak);
                    }
                }
                return tempVakinschrijvingen.ToImmutableList<VakInschrijving>();
            }
        }
        public Cursus(string titel, byte studiepunten) {
            foreach(Cursus cursus in Cursus.AlleCursussen) {
                if(cursus.Titel == titel) {
                    throw new DuplicateDataException("Nieuwe cursus heeft dezelfde naam als een bestaande cursus.", this, cursus);
                }
            }
            this.Titel = titel;
            this.Studiepunten = studiepunten;
            this.id = Cursus.maxId;
            Cursus.maxId++;
            registreerCursus(this);
        }
        public Cursus(string titel):this(titel, 3) {

        }

        public override bool Equals(Object obj) {
            if(obj is null) {
                return false;
            } 
            bool gelijk; 
            if(GetType() != obj.GetType()) {
                gelijk = false;
            } else {
                Cursus temp = (Cursus)obj;
                if(this.Id == temp.Id) {
                    gelijk = true;
                } else {
                    gelijk = false;
                }
            }
            return gelijk;
        }
        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
        public override string ToString() {
            return $"Cursus {this.Titel} heeft {this. Studiepunten} studiepunten";
        } 
        public void ToonOverzicht() {

            Console.WriteLine($"--- ({this.Id}): {this.Studiepunten}stp {this.Titel} ---");

            foreach(var student in Studenten){
                if(student is not null) {
                    Console.WriteLine($"{student.Naam}");
                }
            }
            Console.WriteLine("\n");
        }
        public static void ToonCursussen() {
            Console.WriteLine("Toon cursussen in:");
            Console.WriteLine("1. Stijgende alfabetische volgorde");
            Console.WriteLine("2. Stijgende volgorde van studiepunten");

            int keuze = 0;
            try {
                keuze = Convert.ToInt32(Console.ReadLine());
            } catch(ArgumentException) {
                Console.WriteLine("Keuze moet een getal zijn");
            }
            
            IComparer<Cursus> comparer = null;
            switch(keuze) {
                case(1):
                comparer = new CursusVolgensTitelOplopendComparer();
                    break;
                case(2):
                comparer = new CursusVolgensStudiepuntenOplopendComparer();
                    break;
                default: Console.WriteLine("Ongeldige keuze!");
                    break;
            }
            ImmutableList<Cursus> alleCursussenGesorteerd = AlleCursussen.Sort(comparer);
            foreach (Cursus cursus in alleCursussenGesorteerd) {
                Console.WriteLine(cursus.ToString());
            }
        }
        private static void registreerCursus(Cursus cursus){
            alleCursussen.Add(cursus);
        }
        public static Cursus ZoekCursusOpId(int id) {
            
            foreach (var cursus in AlleCursussen) {
                if (cursus.Id == id) {
                    return cursus; 
                }
            }
            return null;
        }
        public static void DemonstreerCursussen() {

            Cursus.maxId = 1;        //Each method call will stay consistent with maxId.
            Student student1 = new Student("Dimitri Avtenyev",new DateTime(1990,12,2));
            Student student2 = new Student("Kylo Ren", new DateTime(1989,1,1));
            Student student3 = new Student("Sheev Palpatine", new DateTime(1950,1,1));
    
            Cursus communicatie = new Cursus("Communicatie");
            student1.RegistreerVakInschrijving(communicatie, 14);
            student2.RegistreerVakInschrijving(communicatie,13);

            Cursus programmeren = new Cursus("Programmeren");
            programmeren.Studiepunten = 6;
            student1.RegistreerVakInschrijving(programmeren, 17);
            student2.RegistreerVakInschrijving(programmeren, 15);

            Cursus webtechnologie = new Cursus("Webtechnologie", 6);
            student1.RegistreerVakInschrijving(webtechnologie, 19);
            student2.RegistreerVakInschrijving(webtechnologie, 19);

            Cursus databanken = new Cursus("Databanken", 5);
            student1.RegistreerVakInschrijving(databanken, 16);
            student2.RegistreerVakInschrijving(databanken, 15);
            student3.RegistreerVakInschrijving(databanken, 9);

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht();     

            // --- TEST tweerichtingsverkeer vakinschrijvingen binnen cursus-- 
            // foreach(var vakinschrijving in student3.VakInschrijvingen) {
            //     Console.WriteLine(vakinschrijving.Student.Naam);
            //     Console.WriteLine(vakinschrijving.Cursus.Titel);
            // }
            // Console.WriteLine("-----");
            // foreach(var student in programmeren.Studenten) {
            //     Console.WriteLine(student.Naam);
            // }

        }
        public static void CursusToevoegen() {
            Console.WriteLine("Titel van de cursus?");
            string titel = Console.ReadLine();
            Console.WriteLine("Aantal studiepunten?");
            byte studiepunten = Convert.ToByte(Console.ReadLine());
            try {
                new Cursus(titel, studiepunten);
            } catch(DuplicateDataException e) {
                Cursus temp = (Cursus)e.Waarde2;
                Console.WriteLine($"{e.Message} -> ID bestaande cursus: {temp.Id}");
            }
           

        }
    }
}