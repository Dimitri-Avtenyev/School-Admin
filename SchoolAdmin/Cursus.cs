using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    class Cursus
    {
        public string Titel;
        public List<Student> Studenten;
        private int id;
        private static int maxId = 1;
        private byte studiepunten;
        private static List<Cursus> alleCursussen = new List<Cursus>(10);
        public Cursus(string titel, List<Student> studenten, byte studiepunten) {
            this.Titel = titel;
            this.Studenten = studenten;
            this.Studiepunten = studiepunten;
            //alleCursussen.Add(this); ipv registreerCursus?
            this.id = maxId;
            MaxId++;    
        }
        public Cursus(string titel, List<Student> studenten):this(titel, studenten, 3) {
         
        }
        public Cursus(string titel):this(titel, new List<Student>(2), 3) {
      
        }
        public Cursus(string titel, byte studiepunten):this(titel, new List<Student>()) {

        }
        public byte Studiepunten {
            get {
                return studiepunten;
            } private set {
                studiepunten = value;
            }
        }
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
        public static ImmutableList<Cursus> AlleCursussen {
            get {
                return alleCursussen.ToImmutableList();
            }
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
                if(Id == temp.Id) {
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
        public void ToonOverzicht() {

            Console.WriteLine($"--- ({this.Id}): {this.studiepunten}stp {this.Titel} ---");

            foreach(var student in Studenten){
                if(student is not null) {
                    Console.WriteLine($"{student.Naam}");
                }
            }
            Console.WriteLine("\n");
        }
        private static void registreerCursus(Cursus cursus){
            alleCursussen.Add(cursus);
            //  --Voor verandering van List<Cursus> alleCursussen--
            // int? vrijePositie = null;
            // for(int i=0; i<AlleCursussen.Count && vrijePositie is null; i++){
            //     if(AlleCursussen[i] is null) {
            //         vrijePositie = i;
            //     }
            // }
            // if(vrijePositie is not null) {
            //     alleCursussen.Insert((int)vrijePositie, cursus);
            // } else {
            //     Console.WriteLine("Er zijn geen vrije posities meer");
            // }
            
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
    
            Cursus communicatie = new Cursus("Communicatie",new List<Student>(2));
            student1.RegistreerVakInschrijving(communicatie, 14);
            student2.RegistreerVakInschrijving(communicatie,13);
            communicatie.Studenten.Add(student1);
            communicatie.Studenten.Add(student2);
            
            Cursus programmeren = new Cursus("Programmeren");
            programmeren.Studiepunten = 6;
            student1.RegistreerVakInschrijving(programmeren, 17);
            student2.RegistreerVakInschrijving(programmeren, 15);
            programmeren.Studenten.Add(student1);
            programmeren.Studenten.Add(student2);

            Cursus webtechnologie = new Cursus("Webtechnologie", new List<Student>(5), 6);
            student1.RegistreerVakInschrijving(webtechnologie, 19);
            student2.RegistreerVakInschrijving(webtechnologie, 19);
            webtechnologie.Studenten.Add(student1);
            webtechnologie.Studenten.Add(student2);
            
            Cursus databanken = new Cursus("Databanken", new List<Student>(7), 5);
            student1.RegistreerVakInschrijving(databanken, 16);
            student2.RegistreerVakInschrijving(databanken, 15);
            student1.RegistreerVakInschrijving(databanken, 9);
            databanken.Studenten.Add(student1);
            databanken.Studenten.Add(student2);
            databanken.Studenten.Add(student3);

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht(); 
           
            registreerCursus(programmeren);
            registreerCursus(webtechnologie);
            Console.WriteLine(ZoekCursusOpId(2).Titel);
        }
        public static void CursusToevoegen() {
            Console.WriteLine("Titel van de cursus?");
            string titel = Console.ReadLine();
            Console.WriteLine("Aantal studiepunten?");
            byte studiepunten = Convert.ToByte(Console.ReadLine());

            Cursus cursus = new Cursus(titel, studiepunten);

        }
    }
}