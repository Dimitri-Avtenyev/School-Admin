using System;


namespace SchoolAdmin
{
    class Student
    {
        public string Naam;
        public DateTime Geboortedatum;
        public uint Studentennummer;
        private CursusResultaat[] cursusResultaten = new CursusResultaat[5];
        public static uint StudentenTeller = 1;
        
        public string GenereerNaamKaartje() {
            return $"{this.Naam} (STUDENT)";
        }
        public byte BepaalWerkbelasting() {
            byte totaal = 0;
            for (int i=0; i< cursusResultaten.Length; i++) {
                if(this.cursusResultaten[i] is not null) {
                    totaal +=10;
                }
            }
            return totaal;
        }
        public void RegistreerCursusResultaat(string cursus, byte cijfer) {
            int vrijePositie = -1;
            //CursusResultaat nieuwCursusResultaat = new CursusResultaat();
            for(int i=0; i<cursusResultaten.Length && vrijePositie == -1; i++) {
                if(this.cursusResultaten[i] is null) {
                    vrijePositie = i;
                }
            }
            if(vrijePositie > -1) {
                CursusResultaat nieuwCursusResultaat = new CursusResultaat(cursus, cijfer);
                this.cursusResultaten[vrijePositie] = nieuwCursusResultaat;
    
            }
        }
        public void Kwoteer(byte cursusindex,byte behaaldCijfer) {
            if(behaaldCijfer<0 || behaaldCijfer >20) {
                Console.WriteLine("Ongeldig cijfer!");
            } else {
                this.cursusResultaten[cursusindex].Resultaat = behaaldCijfer;
            }
            
        }
        public double Gemiddelde() {
            double gemiddelde = 0.0;
            double som = 0;
            byte counter = 0;
            for(int i=0; i<this.cursusResultaten.Length; i++) {
                if(this.cursusResultaten[i] is not null) {
                som +=cursusResultaten[i].Resultaat;
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
            for(int i=0; i<this.cursusResultaten.Length; i++) {
                if(cursusResultaten[i] is not null) {
                    Console.WriteLine($"{this.cursusResultaten[i].Naam}:".PadRight(20)+$"{this.cursusResultaten[i].Resultaat}"); //alignment needed
                }
            }
            Console.WriteLine($"Gemiddelde:".PadRight(20)+$"{this.Gemiddelde():F2}\n");
        }
        public static void DemonstreerStudent() {

            Student student1 = new Student();
            Student student2 = new Student();
            student1.Naam = "Dimitri Avtenyev";
            student1.Geboortedatum = new DateTime(1990, 12, 2);
            student1.Studentennummer = Student.StudentenTeller;
            Student.StudentenTeller++;
            student1.RegistreerCursusResultaat("Programmeren", 17);
            //student1.Kwoteer(0,17);
            student1.RegistreerCursusResultaat("Webontwikkeling", 18);
            //student1.Kwoteer(1, 18);
            student1.RegistreerCursusResultaat("Databanken", 16);
            //student1.Kwoteer(2, 16);
            student1.ToonOverzicht();
    
            student2.Naam = "Kylo Ren";
            student2.Geboortedatum = new DateTime(1989, 1, 1);
            student2.Studentennummer = Student.StudentenTeller;
            Student.StudentenTeller++;
            student2.RegistreerCursusResultaat("The Force", 19);
            //student2.Kwoteer(0, 19);
            student2.RegistreerCursusResultaat("Programmeren", 13);
            //student2.Kwoteer(1, 13);
            student2.RegistreerCursusResultaat("Databanken", 9);
            //student2.Kwoteer(2, 9);
            student2.ToonOverzicht();
        }

    }
}