// Program.cs
using Controllers;
using System;

class Program
{
    static void Main()
    {
        var controller = new ReservationController();
        controller.LoadReservations();
        int opcion = 0;
        while (opcion != 5)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1. Create a reservation.");
            Console.WriteLine("2. Show reservations.");
            Console.WriteLine("3. Delete reservation by ClientID");
            Console.WriteLine("4. Update reserve.");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            Console.ResetColor();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    controller.CreateReservation();
                    Console.WriteLine("Type someting to proceed.");
                    Console.ReadKey();
                    break;
                case 2:
                    controller.ShowAllReservations();
                    Console.WriteLine("Type someting to proceed.");
                    Console.ReadKey();
                    break;
                case 3:
                    controller.DeleteReservationByClientID();
                    Console.WriteLine("Type someting to proceed.");
                    Console.ReadKey();
                    break;
                case 4:
                    controller.UpdateClientByID();
                    Console.WriteLine("Type someting to proceed.");
                    Console.ReadKey();
                    break;
                case 5:
                    return;
            }
        }
    }
}
