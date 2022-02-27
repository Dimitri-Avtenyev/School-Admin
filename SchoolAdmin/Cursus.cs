using System;

namespace SchoolAdmin
{
    class Cursus
    {
        public string Titel;
        public Student[] Studenten;
        private int id;
        private static int maxId = 1;
        private byte studiepunten;
        public Cursus(string titel, Student[] studenten, byte studiepunten) {
            Titel = titel;
            Studenten = studenten;
            Studiepunten = studiepunten;
            id = maxId;
            MaxId++;    
        }
        public Cursus(string titel, Student[] studenten):this(titel, studenten, 3) {
         
        }
        public Cursus():this("titel", new Student[2], 3) {
      
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
        public void ToonOverzicht() {

            Console.WriteLine($"--- ({this.Id}): {this.studiepunten}stp {this.Titel} ---");

            for(int i=0;i<this.Studenten.Length; i++){
                if(this.Studenten[i] is not null) {
                    Console.WriteLine($"{this.Studenten[i].Naam}");
                }
            }
            Console.WriteLine("\n");
        }
        public static void DemonstreerCursussen() {
            Student student1 = new Student();
            Student student2 = new Student();
            Student student3 = new Student();
            student1.Naam = "Dimitri Avtenyev";
            student2.Naam = "Kylo Ren";
            student3.Naam = "Sheev Palpatine";

            Cursus communicatie = new Cursus();
            communicatie.Titel = "Communicatie";
            communicatie.Studenten[0] = student1;
            communicatie.Studenten[1] = student2;

            Cursus programmeren = new Cursus();
            programmeren.Titel = "Programmeren";
            programmeren.Studiepunten = 6;
            programmeren.Studenten[0] = student1;
            programmeren.Studenten[1] = student2;

            Cursus webtechnologie = new Cursus("Webtechnologie", new Student[5], 6);
            webtechnologie.Titel = "Webtechnologie";
            webtechnologie.Studenten[0] = student1;
            webtechnologie.Studenten[1] = student2;
            
            Cursus databanken = new Cursus("Databanken", new Student[7], 5);
            databanken.Studenten[0] = student1;
            databanken.Studenten[1] = student2;
            databanken.Studenten[2] = student3;

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht();
        }
    }
}