using System;

namespace ExceptionHandling
{
    public static class FlightConfig
    {
        public static readonly string BookingPlatform = "MakeMyTrip";
    }

    public class BookingException : Exception
    {
        public BookingException(string message) : base(message) { }
    }

    public class FlightBooking
    {
        public string PassengerName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime TravelDate { get; set; }

        public FlightBooking(string passengerName, string flightNumber, DateTime travelDate)
        {
            PassengerName = passengerName;
            FlightNumber = flightNumber;
            TravelDate = travelDate;
        }

        public void ConfirmBooking()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(PassengerName))
                {
                    throw new BookingException("Passenger name cannot be empty");
                }

                if (string.IsNullOrWhiteSpace(FlightNumber) || FlightNumber.Length != 6)
                {
                    throw new BookingException("Invalid flight number");
                }

                if (TravelDate < DateTime.Today)
                {
                    throw new BookingException("Travel date cannot be in the past");
                }

                Console.WriteLine("\nFlight booking confirmed successfully");
            }
            catch (BookingException ex)
            {
                Console.WriteLine($"\nBooking failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of flight booking process");
            }
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Booking Platform: {FlightConfig.BookingPlatform}");

            FlightBooking booking1 = new FlightBooking("", "AB1234", DateTime.Today.AddDays(5)); // Invalid passenger name
            FlightBooking booking2 = new FlightBooking("John xavier", "XYZ12", DateTime.Today.AddDays(-1)); // Invalid travel date
            FlightBooking booking3 = new FlightBooking("Anu sharma", "FG5678", DateTime.Today.AddDays(10)); // Valid booking

            booking1.ConfirmBooking();
            booking2.ConfirmBooking();
            booking3.ConfirmBooking();

            if (booking3 is FlightBooking)
            {
                Console.WriteLine("\nbooking3 is a valid FlightBooking object");
            }
        }
    }
}
