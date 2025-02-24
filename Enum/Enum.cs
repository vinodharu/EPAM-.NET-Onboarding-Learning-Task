using System;

namespace Enum
{
    public enum Department
    {
        Cardiology,
        Neurology,
        Pediatrics,
        Orthopedics,
        GeneralMedicine
    }

    public static class HospitalConfig
    {
        public static readonly string HospitalName = "Apollo Hospital";
    }

    public class Patient
    {
        public string PatientName { get; set; }
        public int PatientId { get; private set; } 

        private string _medicalHistory;

        public Patient(string patientName, int patientId, string medicalHistory)
        {
            if (string.IsNullOrWhiteSpace(patientName))
            {
                Console.WriteLine("\nPatient name cannot be empty");
                return;
            }

            if (patientId <= 0)
            {
                Console.WriteLine("\nInvalid patient ID");
                return;
            }

            PatientName = patientName;
            PatientId = patientId;
            _medicalHistory = medicalHistory;
        }

        public void ScheduleAppointment(Department department)
        {
            Console.WriteLine($"\n{PatientName} has scheduled an appointment with {department} department.");
        }

        private void DisplayMedicalHistory()
        {
            Console.WriteLine($"\n{PatientName}'s Medical History: {_medicalHistory}");
        }

        protected void AccessMedicalHistory()
        {
            DisplayMedicalHistory();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to {HospitalConfig.HospitalName}");

            Patient patient1 = new Patient("Bhava Tharani", 2001, "No major issues");
            patient1.ScheduleAppointment(Department.Cardiology);

            Patient patient2 = new Patient("Prahaan", -100, "Diabetes");

            Console.ReadLine();
        }
    }
}
