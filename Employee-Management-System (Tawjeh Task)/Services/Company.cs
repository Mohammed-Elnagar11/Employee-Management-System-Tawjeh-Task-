using System;
using System.Collections.Generic;
using System.Text;
using Employee_Management_System__Tawjeh_Task_.Models;

namespace Employee_Management_System__Tawjeh_Task_.Services
{
    public class Company
    {
        private List<Employee> ActiveEmployees = new List<Employee> ();
        private Dictionary<int, Department> Departments = new Dictionary<int, Department> ();
        private Queue<Employee> onboardingEmployees = new Queue<Employee> ();
        private Stack<string> ActionHistory = new Stack<string> ();
        private HashSet<string> Skills = new HashSet<string> ();

        public Company ()
        {
            //Seed Data
        }
    }
}
