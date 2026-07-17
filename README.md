# Learning Projects Repository

This repository contains my **C#. Python, Java practice projects and exercises** created while learning process.

##  Projects Overview

### 1. Car Rental Reservation System 🚗 (`car-rental-system`)
A robust C# Console Application that simulates a real-world vehicle leasing workflow with persistence and automated financial auditing.
- **Interface:** Command Line Interface (CLI) organized with an interactive control menu.
- **Key Feature:** Automates date conflict mitigation by strictly validating overlapping reservation calendars while computing exact runtime rental quotes based on duration and dynamic daily pricing.
- **Highlights:** Leverages `System.Text.Json` for automated state initialization and data serialization (`data.json`), incorporates modern LINQ pipelines to generate business analytics (e.g., total revenue generation, fleet demand profiles), and implements a clean multi-tiered architecture separating structural `Models` from business-critical `Services`.
- **Note:** *The architectural design parameters, file directory layout, and business operational rules were structured and co-designed using AI (Gemini) assistance, while the complete multi-tier execution, JSON persistence mechanics, and data validation layers were fully implemented by me.*

---

### 2. Hospital Appointment System 🏥 (`hospital-appointment-system`)
A clean, modular console-based application designed to manage clinic workflows and appointment scheduling.
- **Interface:** C# Console Application structured with clear Command Line Interface (CLI) menus.
- **Key Feature:** Automates schedule validation by ensuring patients can only book verified doctor time slots, strictly preventing double-booking conflicts for the same date and time.
- **Highlights:** Implements strong Object-Oriented Architecture (OOP) by separating models into dedicated files, utilizing C# Enums for department filtering, and leveraging LINQ (`.Where`, `.Any`) for efficient in-memory data queries.
- **Note:** *The foundational application architecture and business logic validation were structured and co-designed using AI (Gemini) assistance, while the complete object implementation, refactored multi-file directory structure, and environment setup were managed by me.*

---

### 3. Cute To-Do List Application ✨ (`cute-todo-app`)
A charming desktop task organizer featuring a light pastel aesthetic.
- **Interface:** Built with `CustomTkinter` for a smooth, modern visual layout.
- **Key Feature:** Automates spreadsheet updates by compiling active tasks into a color-coded, custom-styled Excel sheet (`todo_list.xlsx`) saved directly to your desktop.
- **Highlights:** Dynamic checklist widget destruction on removal and auto-fitted Excel table dimensions using `openpyxl`.
- **Note:** *The CustomTkinter GUI layout, widget structures were co-designed and generated using AI (Gemini) assistance, while the complete app architecture, environment structure, and spreadsheet automation logic were implemented by me.*
  
---

##  Project Structure

Each folder inside this repository represents a separate project:

```text
CSharp-Projects
│
├── CarRentalSystem/
├── HOspitalAppoinmentSystem/
├── cute-todo-list/
└── ...
```
Each project includes its own:

- Source code
- README (if needed)
- Description of functionality

---

## How to Use
- Clone the repository:
```git clone https://github.com/irembekdemir/beginner-projects.git```
- Open in IDE
- Navigate to any project folder
- Run the project using F5

---

## Notes
- These projects are created for learning purposes.
- Code may evolve over time as I improve my skills.
- Focus is on understanding logic rather than perfection.

---

## Author
[irem bekdemir](https://github.com/irembekdemir)




