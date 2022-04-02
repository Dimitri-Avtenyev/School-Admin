using System;

namespace SchoolAdmin 
{
    class Program 
    {
        static void Main(string[] args)
        {   
            Console.Clear();
            bool stop = false;
            do{
                Console.WriteLine("Wat wil je doen? (Stoppen met 'stop')");
                Console.WriteLine("1. DemonstreerStudenten uitvoeren");
                Console.WriteLine("2. DemonstreerCursussen uitvoeren");
                Console.WriteLine("3. DemonstreerStudentUitTekstFormaat uitvoeren");
                Console.WriteLine("4. DemonstreerStudieProgramma uitvoeren");
                Console.WriteLine("5. DemonstreerAdministratiefPersoneel uitvoeren");
                string userInput = Console.ReadLine();
                switch(userInput.ToLower()){
                    default: 
                        Console.WriteLine("Ongeldige keuze!");
                        break;
                    case("stop"): 
                        stop = true;
                        break;
                    case("1"): 
                        Student.DemonstreerStudent();
                        break;
                    case("2"):
                        Cursus.DemonstreerCursussen();
                        break;
                    case("3"): 
                        Student.DemonstreerStudentUitTekstFormaat();
                        break;
                    case("4"):
                        StudieProgramma.DemonstreerStudieProgramma();
                    break;
                    case("5"):
                        AdministratiefPersoneel.DemonstreerAdministratiefPersoneel();
                    break;
                }
            } while(!stop);
        }
    }
}