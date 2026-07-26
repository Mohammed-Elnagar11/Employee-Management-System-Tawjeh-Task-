using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System__Tawjeh_Task_.Models
{
    public class Manager : Employee
    {
        List<Employee> TeamMembers { get; set; }
        public Manager(String name, int departmentId, decimal salary) : base(name, departmentId, salary)
        {
            TeamMembers = new List<Employee>();
        }
    }
}