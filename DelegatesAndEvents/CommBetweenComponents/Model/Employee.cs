using System;
using System.Collections.Generic;
using System.Text;

namespace CommBetweenComponents.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
