using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System__Tawjeh_Task_.Models
{
    public class Employee
    {
        private static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }

        public Employee(String name, int departmentId, decimal salary)
        {
            Id = NextId++;
            Name = name;
            HireDate = DateTime.Now;
            DepartmentId = departmentId;
            Salary = salary;
        }
    }
}