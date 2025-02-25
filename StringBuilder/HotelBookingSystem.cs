using System;
using System.Text;

namespace HotelBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine("Welcome to the ITC Grand Hotel");
            message.AppendLine("We hope you enjoy your stay");

            string upperMessage = message.ToString().ToUpper();
            string replacedMessage = upperMessage.Replace("ITC GRAND", "LUXURY INN");

            Console.WriteLine(replacedMessage);
            Console.ReadLine();
        }
    }
}