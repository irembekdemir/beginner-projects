using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAppointmentSystem.Models; // Modellere erişim için
using HospitalAppointmentSystem.Enums;  // Enum yapısına erişim için

namespace HospitalAppointmentSystem
{
    class Program
    {
        static List<Doctor> doctors = new List<Doctor>();
        static List<Patient> patients = new List<Patient>();
        static List<Appointment> appointments = new List<Appointment>();
        
        static int appointmentIdCounter = 1;
        static int patientIdCounter = 1;

        static void Main(string[] args)
        {
            SeedData();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- HOSPITAL APPOINTMENT SYSTEM ---");
                Console.WriteLine("1. List Doctors by Department");
                Console.WriteLine("2. Register New Patient");
                Console.WriteLine("3. Book an Appointment");
                Console.WriteLine("4. View All Appointments");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ListDoctorsMenu(); break;
                    case "2": RegisterPatient(); break;
                    case "3": BookAppointment(); break;
                    case "4": ViewAppointments(); break;
                    case "5": running = false; break;
                }
            }
        }

        static void SeedData()
        {
            doctors.Add(new Doctor(1, "Dr. Emily Smith", Department.Cardiology, new List<string> { "09:00", "10:30", "14:00" }));
            doctors.Add(new Doctor(2, "Dr. Sam Keating", Department.Psychiatry, new List<string> { "11:00", "13:00", "15:30" }));
            doctors.Add(new Doctor(3, "Dr. Stephen Strange", Department.Neurology, new List<string> { "09:30", "11:30", "16:00" }));
            doctors.Add(new Doctor(4, "Dr. John Doe", Department.InternalMedicine, new List<string> { "10:00", "14:30", "15:00" }));
        }

        static void ListDoctorsMenu()
        {
            Console.WriteLine("\nSelect Department:\n0. Cardiology | 1. Psychiatry | 2. Neurology | 3. Internal Medicine");
            if (int.TryParse(Console.ReadLine(), out int deptId) && deptId >= 0 && deptId <= 3)
            {
                Department selectedDept = (Department)deptId;
                var filteredDoctors = doctors.Where(d => d.Specialization == selectedDept).ToList();
                foreach (var doc in filteredDoctors)
                {
                    Console.WriteLine($"ID: {doc.Id} | {doc.Name} | Hours: {string.Join(", ", doc.AvailableHours)}");
                }
            }
        }

        static void RegisterPatient()
        {
            Console.Write("Enter Patient Full Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Patient newPatient = new Patient(patientIdCounter++, name, phone);
            patients.Add(newPatient);
            Console.WriteLine($"Patient registered successfully! ID: {newPatient.Id}");
        }

        static void BookAppointment()
        {
            Console.Write("Enter your Patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId)) return;
            Patient patient = patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null) return;

            Console.Write("Enter Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int docId)) return;
            Doctor doctor = doctors.FirstOrDefault(d => d.Id == docId);
            if (doctor == null) return;

            Console.Write("Enter Date (e.g., 2026-08-12): ");
            string date = Console.ReadLine();
            Console.Write("Choose time slot: ");
            string time = Console.ReadLine();

            if (!doctor.AvailableHours.Contains(time) || appointments.Any(a => a.AppointmentDoctor.Id == docId && a.Date == date && a.Time == time))
            {
                Console.WriteLine("Slot unavailable.");
                return;
            }

            Appointment newAppointment = new Appointment(appointmentIdCounter++, patient, doctor, date, time);
            appointments.Add(newAppointment);
            Console.WriteLine("Booked!");
        }

        static void ViewAppointments()
        {
            foreach (var appt in appointments) appt.DisplayAppointmentInfo();
        }
    }
}