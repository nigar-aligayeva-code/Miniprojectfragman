namespace MiniProject2.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }

        //Foreign key
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}