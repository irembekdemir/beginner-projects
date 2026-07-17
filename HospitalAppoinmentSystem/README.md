# Hospital Appointment System 🏥

A beginner-to-intermediate console-based Hospital Appointment System written in C#. This project demonstrates core Object-Oriented Programming (OOP) concepts, clean code separation, and data manipulation using LINQ.

## Features

- **Department Categorization:** Uses C# Enums to handle hospital departments (`Cardiology`, `Psychiatry`, `Neurology`, `InternalMedicine`).
- **Patient Registration:** Allows dynamic creation of patients with auto-incrementing IDs.
- **Doctor Filtering:** Lists doctors and their available hours based on the selected department.
- **Appointment Booking:** Connects Patients and Doctors with strict business logic validation:
  - Verifies if Patient ID and Doctor ID exist.
  - Ensures the selected time slot is valid for the doctor.
  - Prevents double-booking the same doctor at the same date and time.
- **Appointment Tracking:** Displays all active appointments scheduled in the system memory.

## Architecture & Directory Structure

The project follows a structured file separation approach rather than cluttering a single file:

```text
HospitalAppointmentSystem/
│
├── Enums/
│   └── Department.cs          # Contains department selections
│
├── Models/
│   ├── Doctor.cs              # Doctor class with availability profiles
│   ├── Patient.cs             # Patient identification details
│   └── Appointment.cs         # Core assignment binder (Patient + Doctor + Time)
│
└── Program.cs                 # Application hub, mock database, and CLI loop
