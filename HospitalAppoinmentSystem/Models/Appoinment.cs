using System;

namespace HospitalAppointmentSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient AppointmentPatient { get; set; }
        public Doctor AppointmentDoctor { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Appointment(int id, Patient patient, Doctor doctor, string date, string time)
        {
            Id = id;
            AppointmentPatient = patient;
            AppointmentDoctor = doctor;
            Date = date;
            Time = time;
        }

        public void DisplayAppointmentInfo()
        {
            Console.WriteLine($"[Appt ID: {Id}] Patient: {AppointmentPatient.Name} | Doctor: {AppointmentDoctor.Name} ({AppointmentDoctor.Specialization}) | Date: {Date} at {Time}");
        }
    }
}