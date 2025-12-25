using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HelloConsoleEF
{
    class Program
    {

        static void ShowMenu()
        {
            Console.WriteLine("Chose option:");
            Console.WriteLine("1. Display all countries");
            Console.WriteLine("2. Display all actors");
            Console.WriteLine("3. Display actors from sellected country");
            Console.WriteLine("4. Add country");
            Console.WriteLine("5. Add actor");
            Console.WriteLine("x. Exit");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                char choice = Console.ReadLine().Trim().ToUpper()[0];
                if (choice == 'X')
                    return;
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("Informations from the database:");
                        DisplayConutries();
                        break;
                    case '2':
                        Console.WriteLine("Informations from the database:");
                        DisplayActors();
                        break;
                    case '3':
                        Console.WriteLine("Enter the name of the country.");
                        string countryName = Console.ReadLine().Trim();
                        Console.WriteLine($"\nActros from '{countryName}' are: \n");
                        DisplayActors(countryName);
                        break;
                    case '4':
                        Console.WriteLine("Enter the name of the country.");
                        string countryNameToAdd = Console.ReadLine();
                        AddCountry(countryNameToAdd);
                        break;
                    case '5':
                        Console.WriteLine("Enter the last name of the actor.");
                        string actorLastName = Console.ReadLine();
                        Console.WriteLine("Enter the first name of the actor.");
                        string actorFirstName = Console.ReadLine();
                        DisplayConutries();
                        Console.WriteLine("Enter the ID of the country (among displayed).");
                        int idCountry = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the birth date of the actor (YYYY-MM-DD).");
                        string actorBirthDate = Console.ReadLine();
                        string[] dateParts = actorBirthDate.Split('-');
                        DateOnly? dateOfBirth = null;
                        if (dateParts.Length == 3)
                        {
                            dateOfBirth = new DateOnly(
                            Convert.ToInt32(dateParts[0]),
                            Convert.ToInt32(dateParts[1]),
                            Convert.ToInt32(dateParts[2])
                            );
                            AddActor(actorLastName, actorFirstName, idCountry, dateOfBirth);
                        }
                        break;
                    default:
                        Console.WriteLine("Non-existing selection.");
                        break;
                }
            }
        }


        private static void DisplayConutries()
        {
            using (var context = new ProbaContext())
            {
                var countries = context.Country;
                var data = new StringBuilder();
                foreach (Country c in countries)
                {
                    data.AppendLine("---");
                    data.AppendLine($"CountryId: {c.CountryId}");
                    data.AppendLine($"Name: {c.Name}");
                }
                Console.WriteLine(data.ToString());
            }
        }
        private static void DisplayActors()
        {
            using (var context = new ProbaContext())
            {
                var actors = context.Actor.Include(p => p.Country);
                var data = new StringBuilder();
                foreach (Actor a in actors)
                {
                    data.AppendLine("---");
                    data.AppendLine($"Last name: {a.LastName}");
                    data.AppendLine($"First name: {a.FirstName}");
                    data.AppendLine($"Country: {a.Country.Name}");
                    data.AppendLine($"Date of birth: {a.DateOfBirth}");
                }
                Console.WriteLine(data.ToString());
            }
        }

        private static void DisplayActors(string countryName)
        {
            using (var context = new ProbaContext())
            {
                var listaGradId = context.Grad.Where(x => x.Naziv.Equals(countryName))
                .Select(x => x.Id).ToList();
                if (listaGradId.Count <= 0)
                {
                    Console.WriteLine("Ovog grada nema u bazi!");
                    return;
                }
                int gradId = listaGradId[0];

                var skole = context.Skola.Where(x => x.GradId == gradId)
                .Include(x => x.Grad);

                var data = new StringBuilder();
                foreach (var s in skole)
                {
                    data.AppendLine($"Name: {s.Naziv}");
                    data.AppendLine($"Adresa: {s.Adresa}");
                }
                Console.WriteLine(data.ToString());
            }

        }
        private static void AddCountry(string imeGrada)
        {
            using (var context = new ProbaContext())
            {
                Country g = new Country();
                g.Name = imeGrada;
                context.Grad.Add(g);
                context.SaveChanges();
            }
        }

        private static void AddActor(string imeSkole, string adresaSkole, int idGrada, DateOnly? dob)
        {
            using (var context = new ProbaContext())
            {
                Skola s = new Skola();
                s.Naziv = imeSkole;
                s.Adresa = adresaSkole;
                s.GradId = idGrada;
                context.Skola.Add(s);
                context.SaveChanges();
            }
        }

    }
}
