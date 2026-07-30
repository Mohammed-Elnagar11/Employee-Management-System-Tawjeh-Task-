using Employee_Management_System__Tawjeh_Task_.Services;

Company company = new Company();
bool running = true;

do
{
    PrintMenu();
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddEmployeeFlow();
            break;
        case "2":
            AddDepartmentFlow();
            break;
        case "3":
            company.ProcessOnboarding();
            break;
        case "4":
            AddSkillFlow();
            break;
        case "5":
            SearchByIdFlow();
            break;
        case "6":
            SearchByNameFlow();
            break;
        case "7":
            DisplayByDepartmentFlow();
            break;
        case "8":
            company.CalculateAverageSalary();
            break;
        case "9":
            company.DisplayDepartmentReport();
            break;
        case "10":
            company.DisplayAllSkills();
            break;
        case "11":
            company.DisplayActionHistory();
            break;
        case "12":
            company.DisplayAllDepartments();
            break;
        case "0":
            running = false;
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option, please choose a number from the menu.");
            break;
    }

} while (running);

void PrintMenu()
{
    Console.WriteLine("\n==================== Employee Management System ====================");
    Console.WriteLine("1.  Add Employee (to Onboarding Queue)");
    Console.WriteLine("2.  Add Department");
    Console.WriteLine("3.  Process Next Onboarding Employee (Dequeue)");
    Console.WriteLine("4.  Add Skill to Employee");
    Console.WriteLine("5.  Search Employee by Id");
    Console.WriteLine("6.  Search Employee by Name");
    Console.WriteLine("7.  Display Employees by Department");
    Console.WriteLine("8.  Calculate Average Salary");
    Console.WriteLine("9.  Display Department Report");
    Console.WriteLine("10. Display All Unique Skills");
    Console.WriteLine("11. Display Action History (Latest First)");
    Console.WriteLine("12. Display All Departments");
    Console.WriteLine("0.  Exit");
    Console.Write("Choose an option: ");
}

// ---------- Input helpers (keep invalid input from crashing the app) ----------

int ReadInt(string prompt)
{
    int value;
    Console.Write(prompt);
    while (!int.TryParse(Console.ReadLine(), out value))
    {
        Console.Write("Invalid number, try again: ");
    }
    return value;
}

decimal ReadPositiveDecimal(string prompt)
{
    decimal value;
    Console.Write(prompt);
    while (!decimal.TryParse(Console.ReadLine(), out value) || value < 0)
    {
        Console.Write("Invalid amount, enter a non-negative number: ");
    }
    return value;
}

string ReadNonEmptyString(string prompt)
{
    string? value;
    Console.Write(prompt);
    value = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(value))
    {
        Console.Write("Value cannot be empty, try again: ");
        value = Console.ReadLine();
    }
    return value;
}

// ---------- Menu action flows ----------

void AddEmployeeFlow()
{
    company.DisplayAllDepartments();
    string name = ReadNonEmptyString("Employee name: ");
    int deptId = ReadInt("Department Id: ");
    decimal salary = ReadPositiveDecimal("Salary: ");
    company.AddEmployee(name, deptId, salary);
}

void AddDepartmentFlow()
{
    string name = ReadNonEmptyString("Department name: ");
    company.AddDepartment(name);
}

void AddSkillFlow()
{
    int id = ReadInt("Employee Id: ");
    string skill = ReadNonEmptyString("Skill name: ");
    company.AddEmployeeSkill(id, skill);
}

void SearchByIdFlow()
{
    int id = ReadInt("Employee Id: ");
    company.SearchEmployeeById(id);
}

void SearchByNameFlow()
{
    string name = ReadNonEmptyString("Employee name (or part of it): ");
    company.SearchEmployeeByName(name);
}

void DisplayByDepartmentFlow()
{
    company.DisplayAllDepartments();
    int deptId = ReadInt("Department Id: ");
    company.DisplayEmployeesByDepartment(deptId);
}