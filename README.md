# Employee Management System

Console application (C#) built to practice the core .NET Collections — `List`, `Dictionary<TKey,TValue>`,
`Queue`, `Stack`, and `HashSet` — by combining all five inside one small employee-management domain.

This is a **learning project**. It intentionally does not use LINQ, Generics (custom), Delegates, Events,
Async/Await, File Handling, a Database, EF Core, DI, or ASP.NET Core. All filtering, searching, and
aggregation is done with manual loops, and all data lives in memory only (nothing is saved after the
program closes).

## Project Structure

```
EmployeeManagementSystem/
├── Models/
│   ├── Employee.cs
│   ├── Manager.cs
│   └── Department.cs
├── Services/
│   └── Company.cs
└── Program.cs
```

## Collections Used

| Collection | Field in `Company` | Purpose |
|---|---|---|
| `List<Employee>` | `ActiveEmployees` | Active employees currently working at the company |
| `Dictionary<int, Department>` | `Departments` | Fast lookup of a department by its Id |
| `Queue<Employee>` | `onboardingQueue` | New employees wait here, processed FIFO |
| `Stack<string>` | `ActionHistory` | Log of actions, most recent shown first (LIFO) |
| `HashSet<string>` | `Skills` | Unique skills across the whole company, no duplicates |

## Features

- Add a new employee → goes into the onboarding queue
- Process onboarding (`Dequeue`) → moves the next employee into the active list
- Add a new department
- Add a skill to an employee → added to the company-wide unique skill set
- Search for an employee by Id or by (partial) name
- Display all employees in a given department
- Calculate the average salary of active employees (manual loop, no LINQ)
- Department report: employee count per department (manual loop, no `GroupBy`)
- Display the action history, most recent action first
- Display all unique skills
- Display all departments (with their Ids, needed before adding employees)

## Seed Data

On startup, `Company`'s constructor seeds:
- 3 departments: IT, HR, Finance
- 4 employees added to onboarding
- 3 of them processed into active employees (the 4th, Khaled, is left in the
  onboarding queue on purpose, so you can try option 3 from the menu immediately)
- A few skills assigned to the active employees

This is only so the app isn't empty on first run — everything can also be added manually through the menu.

## How to Run

```bash
dotnet run
```

You'll see a numbered menu. Enter a number and press Enter to run that action; the app loops until you
choose `0` to exit. Invalid input (letters instead of numbers, empty names, negative salaries) is caught
and re-prompted instead of crashing the app.

## Notes / Design Decisions

- **Action History vs. Undo**: the Stack only stores a text log of what happened, in LIFO order for display.
  It does not store reversible operations, so it cannot actually undo anything — that would require storing
  the inverse of each action (planned as a later topic, after Delegates).
- **IDs**: `Employee` and `Department` each generate their own Id internally via a static counter, so Ids
  are unique and auto-incrementing without any external ID generator.
- **Manager**: inherits from `Employee` and adds a `TeamMembers` list, modeling a manager who owns a team.
