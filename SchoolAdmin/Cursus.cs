using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SchoolAdmin
{
    class Cursus
    {
        public string Titel;
        public Student[] Studenten;
        private int id;
        private static int maxId = 1;
        private byte studiepunten;
        private static List<Cursus> alleCursussen = new List<Cursus>(10);
        public Cursus(string titel, Student[] studenten, byte studiepunten) {
            this.Titel = titel;
            this.Studenten = studenten;
            this.Studiepunten = studiepunten;
            this.id = maxId;
            MaxId++;    
        }
        public Cursus(string titel, Student[] studenten):this(titel, studenten, 3) {
         
        }
        public Cursus(string titel):this(titel, new Student[2], 3) {
      
        }
        public byte Studiepunten {
            get {
                return studiepunten;
            }
            private set {
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
            }
            set {
                maxId = value;
            }
        }
        public static ImmutableList<Cursus> AlleCursussen {
            get {
                return alleCursussen.ToImmutableList();
            }
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
            /* --Voor verandering van List<Cursus> alleCursussen--
            int? vrijePositie = null;
            for(int i=0; i<AlleCursussen.Count && vrijePositie is null; i++){
                if(AlleCursussen[i] is null) {
                    vrijePositie = i;
                }
            }
            if(vrijePositie is not null) {
                alleCursussen.Insert((int)vrijePositie, cursus);
            } else {
                Console.WriteLine("Er zijn geen vrije posities meer");
            }
            */ 
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
    
            Cursus communicatie = new Cursus("Communicatie",new Student[2]);
            student1.RegistreerCursusResultaat(communicatie, 14);
            student2.RegistreerCursusResultaat(communicatie,13);
            communicatie.Studenten[0] = student1;
            communicatie.Studenten[1] = student2;

            Cursus programmeren = new Cursus("Programmeren");
            programmeren.Studiepunten = 6;
            student1.RegistreerCursusResultaat(programmeren, 17);
            student2.RegistreerCursusResultaat(programmeren, 15);
            programmeren.Studenten[0] = student1;
            programmeren.Studenten[1] = student2;

            Cursus webtechnologie = new Cursus("Webtechnologie", new Student[5], 6);
            student1.RegistreerCursusResultaat(webtechnologie, 19);
            student2.RegistreerCursusResultaat(webtechnologie, 19);
            webtechnologie.Studenten[0] = student1;
            webtechnologie.Studenten[1] = student2;
            
            Cursus databanken = new Cursus("Databanken", new Student[7], 5);
            student1.RegistreerCursusResultaat(databanken, 16);
            student2.RegistreerCursusResultaat(databanken, 15);
            student1.RegistreerCursusResultaat(databanken, 9);
            databanken.Studenten[0] = student1;
            databanken.Studenten[1] = student2;
            databanken.Studenten[2] = student3;

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht(); 
           
            registreerCursus(programmeren);
            registreerCursus(webtechnologie);
            Console.WriteLine(ZoekCursusOpId(2).Titel);
        }
    }
}