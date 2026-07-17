using System.Collections.Generic;
using HospitalAppointmentSystem.Enums;

namespace HospitalAppointmentSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Specialization { get; set; }
        public List<string> AvailableHours { get; set; }

        public Doctor(int id, string name, Department specialization, List<string> hours)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
            AvailableHours = hours;
        }
    }
}