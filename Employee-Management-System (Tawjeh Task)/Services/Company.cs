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
    }
}
