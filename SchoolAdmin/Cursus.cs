using System;

namespace SchoolAdmin
{
    class Cursus
    {
        public string Titel;
        public Student[] Studenten = new Student[2];

        public void ToonOverzicht() {

            Console.WriteLine($"---{this.Titel}---");

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
            student1.Naam = "Dimitri Avtenyev";
            student2.Naam = "Kylo Ren";

            Cursus communicatie = new Cursus();
            communicatie.Titel = "Communicatie";
            communicatie.Studenten[0] = student1;
            communicatie.Studenten[1] = student2;

            Cursus programmeren = new Cursus();
            programmeren.Titel = "Programmeren";
            programmeren.Studenten[0] = student1;
            programmeren.Studenten[1] = student2;

            Cursus webtechnologie = new Cursus();
            webtechnologie.Titel = "Webtechnologie";
            webtechnologie.Studenten[0] = student1;
            webtechnologie.Studenten[1] = student2;
            
            Cursus databanken = new Cursus();
            databanken.Titel = "Databanken";
            databanken.Studenten[1] = student1;

            communicatie.ToonOverzicht();
            programmeren.ToonOverzicht();
            webtechnologie.ToonOverzicht();
            databanken.ToonOverzicht();
        }
    }
}