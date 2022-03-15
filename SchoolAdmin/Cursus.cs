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
            Cursus.maxId = 1;        //Each method call will stay consistent with maxId.
            Student student1 = new Student("Dimitri Avtenyev",new DateTime(1990,12,2));
            Student student2 = new Student("Kylo Ren", new DateTime(1989,1,1));
            Student student3 = new Student("Sheev Palpatine", new DateTime(1950,1,1));

            Cursus communicatie = new Cursus("Communicatie",new Student[2]);
            student1.RegistreerCursusResultaat(communicatie.Titel, 14);
            student2.RegistreerCursusResultaat(communicatie.Titel,13);
            communicatie.Studenten[0] = student1;
            communicatie.Studenten[1] = student2;

            Cursus programmeren = new Cursus("Programmeren");
            programmeren.Studiepunten = 6;
            student1.RegistreerCursusResultaat(programmeren.Titel, 17);
            student2.RegistreerCursusResultaat(programmeren.Titel, 15);
            programmeren.Studenten[0] = student1;
            programmeren.Studenten[1] = student2;

            Cursus webtechnologie = new Cursus("Webtechnologie", new Student[5], 6);
            student1.RegistreerCursusResultaat(webtechnologie.Titel, 19);
            student2.RegistreerCursusResultaat(webtechnologie.Titel, 19);
            webtechnologie.Studenten[0] = student1;
            webtechnologie.Studenten[1] = student2;
            
            Cursus databanken = new Cursus("Databanken", new Student[7], 5);
            student1.RegistreerCursusResultaat(databanken.Titel, 16);
            student2.RegistreerCursusResultaat(databanken.Titel, 15);
            student1.RegistreerCursusResultaat(databanken.Titel, 9);
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