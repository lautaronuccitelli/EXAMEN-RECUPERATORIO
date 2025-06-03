using System;

namespace Views
{
    public static class ReservationView
    {
        //Metodo para mostrar un mensaje.
        public static void ShowMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
        //Metodo para que el usuario ingrese un input.
        public static void ShowMsg(string msg)
        {
            Console.Write($"{msg}");
        }
    }
}

