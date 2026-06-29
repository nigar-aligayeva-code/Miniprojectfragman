using System.Collections.Generic;
using MiniProject2.Entities;

namespace MiniProject2.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}