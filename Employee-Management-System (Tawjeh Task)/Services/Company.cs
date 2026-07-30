using Employee_Management_System__Tawjeh_Task_.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Employee_Management_System__Tawjeh_Task_.Services
{
    public class Company
    {
        private List<Employee> ActiveEmployees = new List<Employee>();
        private Dictionary<int, Department> Departments = new Dictionary<int, Department>();
        private Queue<Employee> onboardingQueue = new Queue<Employee>();
        private Stack<string> ActionHistory = new Stack<string>();
        private HashSet<string> Skills = new HashSet<string>();

        public Company()
        {
            //Seed Data
        }
        public void AddEmployee(String name, int departmentId, decimal salary)
        {
            if (!Departments.ContainsKey(departmentId))
            {
                Console.WriteLine($"Department with ID {departmentId} not found!");
                return;
            }
            Employee newEmp = new Employee(name, departmentId, salary);
            onboardingQueue.Enqueue(newEmp);
            ActionHistory.Push($"Added '{name}' to onboarding queue (Dept: {departmentId})");
            Console.WriteLine($"'{name}' added to onboarding queue!");
        }
        public void AddDepartment(String name)
        {
            foreach (var dept in Departments.Values)
            {
                if (dept.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine($"Department '{name}' already exists!");
                    return;
                }
            }
            Department newDept = new Department(name);
            Departments.Add(newDept.Id, newDept);
            ActionHistory.Push($"Added department: '{name}' (ID: {newDept.Id})");
            Console.WriteLine($"Department '{name}' added with ID: {newDept.Id}");
        }
        public void ProcessOnboarding()
        {
            if (onboardingQueue.Count <= 0)
            {
                Console.WriteLine("No employees in onboarding queue!");
                return;
            }

            Employee emp = onboardingQueue.Dequeue();
            ActiveEmployees.Add(emp);
            ActionHistory.Push($"Processed '{emp.Name}' from onboarding (Dept: {emp.DepartmentId})");
            Console.WriteLine($"'{emp.Name}' is now an active employee!");
        }
        public void AddEmployeeSkill(int Id, string Skill)
        {
            foreach (Employee emp in ActiveEmployees)
            {
                if (emp.Id == Id)
                {
                    if (!Skills.Contains(Skill))
                    {
                        Skills.Add(Skill);
                        ActionHistory.Push($"Added skill '{Skill}' to company Skills");
                        Console.WriteLine($"Skill '{Skill}' added to company Skills");
                    }
                    else { Console.WriteLine($"Skill '{Skill}' already exists in company!"); }
                    return;
                }
            }
            Console.WriteLine($" Employee with ID {Id} not found!");
        }
        public void SearchEmployeeById(int Id)
        {
            foreach (Employee emp in ActiveEmployees)
            {
                if (emp.Id == Id)
                {
                    Console.WriteLine($"\nEmployee found:");
                    Console.WriteLine($"ID: {emp.Id}");
                    Console.WriteLine($"Name: {emp.Name}");
                    Console.WriteLine($"Department ID: {emp.DepartmentId}");
                    Console.WriteLine($"Salary: {emp.Salary:C}");
                    Console.WriteLine($"Hire Date: {emp.HireDate}");
                    return;
                }
            }
            Console.WriteLine($"Employee with ID {Id} not found!");
        }
        public void SearchEmployeeByName(string Name)
        {
            bool found = false;
            foreach (Employee emp in ActiveEmployees)
            {
                if (emp.Name.ToLower().Contains(Name.ToLower()))
                {
                    Console.WriteLine($"\nEmployee found:");
                    Console.WriteLine($"ID: {emp.Id}");
                    Console.WriteLine($"Name: {emp.Name}");
                    Console.WriteLine($"Department ID: {emp.DepartmentId}");
                    Console.WriteLine($"Salary: {emp.Salary:C}");
                    Console.WriteLine($"Hire Date: {emp.HireDate}");
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine($"No employees found with name containing '{Name}'!");
            }
        }
        public void DisplayEmployeesByDepartment(int DeptId)
        {
            if (!Departments.ContainsKey(DeptId))
            {
                Console.WriteLine($"Department with ID {DeptId} not found!");
                return;
            }

            string deptName = Departments[DeptId].Name;
            Console.WriteLine($"\n=== Employees in Department: {deptName} ===");

            bool found = false;
            foreach (Employee emp in ActiveEmployees)
            {
                if (emp.DepartmentId == DeptId)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary:C}");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("No active employees in this department.");
        }
        public void CalculateAverageSalary()
        {
            if (ActiveEmployees.Count == 0)
            {
                Console.WriteLine("\nNo active employees to calculate average salary!");
                return;
            }

            decimal total = 0;
            foreach (Employee emp in ActiveEmployees)
            {
                total += emp.Salary;
            }

            decimal average = total / ActiveEmployees.Count;
            Console.WriteLine("\n=== Average Salary ===");
            Console.WriteLine($"Total Employees: {ActiveEmployees.Count}");
            Console.WriteLine($"Total Salary: {total:C}");
            Console.WriteLine($"Average Salary: {average:C}");
            ActionHistory.Push("Calculated average salary");
        }
        public void DisplayDepartmentReport()
        {
            Console.WriteLine("\n=== Department Report ===");

            if (Departments.Count == 0)
            {
                Console.WriteLine("No departments available.");
                return;
            }

            foreach (var dept in Departments.Values)
            {
                int count = 0;
                foreach (Employee emp in ActiveEmployees)
                {
                    if (emp.DepartmentId == dept.Id)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Department: {dept.Name} (ID: {dept.Id}) - Employees: {count}");
            }
            ActionHistory.Push("Displayed department report");
        }
        public void DisplayAllSkills()
        {
            Console.WriteLine("\n=== Unique Skills in Company ===");

            if (Skills.Count == 0)
            {
                Console.WriteLine("No skills added yet.");
                return;
            }

            int counter = 1;
            foreach (string skill in Skills)
            {
                Console.WriteLine($"{counter}. {skill}");
                counter++;
            }
            Console.WriteLine($"Total unique skills: {Skills.Count}");
        }
        public void DisplayActionHistory()
        {
            Console.WriteLine("\n=== Action History (Latest First) ===");

            if (ActionHistory.Count == 0)
            {
                Console.WriteLine("No actions recorded yet.");
                return;
            }

            int counter = 1;
            foreach (string action in ActionHistory)
            {
                Console.WriteLine($"{counter}. {action}");
                counter++;
            }
        }
    }
}
