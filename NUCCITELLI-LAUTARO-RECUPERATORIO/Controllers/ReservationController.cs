using System.Collections.Generic;

// Controllers/ReservationController.cs
namespace Controllers
{
    using System;
    using Models;
    using Repository;
    using Views;

    public class ReservationController
    {
        private List<Reservation> reservationList = new List<Reservation>();
        private ClientController cController;
        private DestinationController dController;

        public ReservationController()
        {
            cController = new ClientController();
            dController = new DestinationController();
            LoadReservations();
        }

        // MÉTODOS DE CARGA Y GUARDADO DE DATOS:
        public void LoadReservations()
        {
            reservationList = Repository<Reservation>.ObtenerTodos("reservas");
        }

        public void SaveReservations()
        {
            Repository<Reservation>.GuardarLista("reservas", reservationList);
        }

        // MÉTODOS A COMPLETAR:
        public void CreateReservation() 
        {
            var c = cController.LoadClient();
            var d = dController.CreateDestination();

            if(c == null || d.Count == 0)
            {
                Console.ForegroundColor = System.ConsoleColor.Red;
                ReservationView.ShowMessage("ERROR: no clients / destinations loaded.");
                return;
                Console.ResetColor();
            }

            var r = new Reservation { client = c, destinationList = d };
            reservationList.Add(r);
            SaveReservations();
            Console.ForegroundColor = ConsoleColor.Green;
            ReservationView.ShowMessage("Reservation added.");
            Console.ResetColor();
        }

        //Metodo que valida si hay reservas.
        public void Validation()
        {
            if (reservationList.Count == 0)
            {
                Console.ForegroundColor = System.ConsoleColor.Red;
                ReservationView.ShowMessage("ERROR: no reservations loaded.");
                return;
                Console.ResetColor();
            }
        }

        public void ShowAllReservations() 
        {
            Validation();
            for (int i = 0; i < reservationList.Count; i++)
            {
                var r = reservationList[i];
                Console.ForegroundColor = ConsoleColor.Blue;
                ReservationView.ShowMessage($"========== RESERVATION NUMBER: #{i + 1} ==========");
                ReservationView.ShowMessage($"Reservation number: #{i + 1}");
                cController.ShowClient(r.client);
                dController.ShowDestinations(r.destinationList);
                ReservationView.ShowMessage($"Total Price: {r.CalculateTotal()}");
                ReservationView.ShowMessage($"Total Price With Tax: {r.CalculateTotalWithTax()}");
                ReservationView.ShowMessage("===================================================");

                Console.ResetColor();
            }
        }
        public void DeleteReservationByClientID() 
        {
            Validation();
            ShowAllReservations();
            Console.ForegroundColor = ConsoleColor.Blue;
            ReservationView.ShowMsg("Select the Client ID of the reservation you want to delete: ");
            string inputID = Console.ReadLine();
            Console.ResetColor();

            var reservationToDelete = reservationList.Find(r => r.client.ID == inputID);

            if (reservationToDelete != null)
            {
                reservationList.Remove(reservationToDelete);
                SaveReservations();
                Console.ForegroundColor = ConsoleColor.Green;
                ReservationView.ShowMessage("Reservation deleted.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ReservationView.ShowMessage("ERROR: No ID found.");
                Console.ResetColor();
            }
        }
        public void UpdateClientByID() 
        {
            Validation();
            ShowAllReservations();
            Console.ForegroundColor = ConsoleColor.Blue;
            ReservationView.ShowMsg("Select the number of the reservation you want to update: ");
            int input = int.Parse(Console.ReadLine()) - 1;
            Console.ResetColor();
            if (input < 0 || input > reservationList.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ReservationView.ShowMessage("ERROR: Not valid input.");
                Console.ResetColor();
            }
            var newClient = cController.LoadClient();
            var newDestination = dController.CreateDestination();

            reservationList[input].client = newClient;
            reservationList[input].destinationList = newDestination;

            SaveReservations();
            Console.ForegroundColor = ConsoleColor.Green;
            ReservationView.ShowMessage("Reservation added.");
            Console.ResetColor();
        }
    }
}
