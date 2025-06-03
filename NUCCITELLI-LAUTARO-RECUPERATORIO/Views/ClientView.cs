using System;

namespace Views
{
    using Models;

    public static class ClientView
    {
        public static Client CreateClient()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("=== Create Client ===");
                Console.Write("Name: ");
                string name = getValidation();

                Console.Write("Last name: ");
                string lastName = getValidation();

                Console.Write("ID: ");
                string id = getValidation(true);

                Console.Write("Email: ");
                string email = getValidation(false, true);
                Console.ResetColor();

                return new Client(name, lastName, id, email);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Client added.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
                return null;
                Console.ResetColor();
            }
        }

        public static void ShowClient(Client client)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----CLIENT-----");
            Console.WriteLine($"Cliente: {client.Name} {client.LastName} - ID: {client.ID} - Email: {client.Email}");
            Console.ResetColor();
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
