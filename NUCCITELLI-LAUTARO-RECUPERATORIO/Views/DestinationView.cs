using System;
using System.Collections.Generic;

namespace Views
{
    using Models;

    public static class DestinationView
    {
        public static List <Destination> CreateDestination()
        {
            List<Destination> list = new();
            string input;
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("=== Create Destination ===");
                    Console.Write("Name of the destination: ");
                    string name = getValidation();

                    Console.Write("Base price: ");
                    double basePrice = double.Parse(getValidation(true));

                    Console.Write("Country: ");
                    string country = getValidation();


                    list.Add(new Destination(name, basePrice, country));

                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Destination added.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {ex.Message}");
                    return null;
                    Console.ResetColor();
                }
            
                Console.WriteLine("Do you want to add a new destination (y/n)");
                input = getValidation().ToLower();
            } while (input == "y");
            return list;
        }

        public static void ShowDestination(List<Destination> list)
        {
            foreach(var d in list)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-----DESTINATIONS-----");
                Console.WriteLine($"Name: {d.Name} Base Price: {d.BasePrice} Country: {d.Country}");
                Console.ResetColor();
            }
        }

        //Metodo para verificiar si la respuestas e un email o un numero.
        public static string getValidation(bool isNumeric = false, bool isEmail = false)
        {
            bool good = false;
            string rta;
            do
            {
                rta = Console.ReadLine();
                if (isNumeric && double.TryParse(rta, out double rtaParsed) && !string.IsNullOrEmpty(rta))
                {
                    good = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(rta) && !isEmail)
                {
                    good = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(rta) && isEmail && rta.Contains("@"))
                {
                    good = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: not valid input.");
                    Console.ResetColor();
                }
            } while (!good);
            return rta;
        }
    }
}

