using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Employee_Management_System__Tawjeh_Task_.Models
{
    public class Department
    {
        private static int NextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public Department(String name)
        {
            Id = NextId++;
            Name = name;
        }
    }
}