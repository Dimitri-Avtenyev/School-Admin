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
                Console.WriteLine("6. DemonstreerLectoren uitvoeren\n---");
                Console.WriteLine("7. Student toevoegen");
                Console.WriteLine("8. Cursus toevoegen");
                Console.WriteLine("9. VakInschrijving toevoegen");
                Console.WriteLine("10. Inschrijvingsgegevens tonen\n");
                Console.Write(">");
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
                    case("6"):
                        Lector.DemonstreerLectoren();
                    break;
                    case("7"):
                        Student.StudentToevoegen();
                    break;
                    case("8"):
                        Cursus.CursusToevoegen();
                    break;
                    case("9"):
                        VakInschrijving.VakInschrijvingToevoegen();
                    break;
                    case("10"):
                       VakInschrijving.ToonInschrijvingsGegevens();
                    break;
                }
            } while(!stop);
        }

    }
}