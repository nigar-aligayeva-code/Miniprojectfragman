using System;
using Microsoft.EntityFrameworkCore;
using MiniProject2.DAL;
using MiniProject2.Entities;
using MiniProject2.Repositories;

namespace MiniProject2.Services
{
    public class EmployeeService
    {
        private readonly Repository<Employee> _repo;
        private readonly AppDbContext _context;
        private readonly DepartmentService _deptService;

        public EmployeeService(AppDbContext context, DepartmentService deptService)
        {
            _context = context;
            _repo = new Repository<Employee>(context);
            _deptService = deptService;
        }

        public void Add()
        {
            var departments = _deptService.GetAll();

            if (departments.Count == 0)
            {
                Console.WriteLine("Evvelce sobe elave edin!");
                return;
            }

            Console.WriteLine("Movcud sobeler:");
            foreach (var d in departments)
                Console.WriteLine($"  [{d.Id}] {d.Name}");

            while (true)
            {
                Console.Write("\nAd (0 - menu): ");
                string name = Console.ReadLine();
                if (name == "0") return;

                Console.Write("Soyad: ");
                string surname = Console.ReadLine();

                Console.Write("Maas: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                {
                    Console.WriteLine("Yanlish maas formati!");
                    continue;
                }

                Console.Write("Sobe ID: ");
                if (!int.TryParse(Console.ReadLine(), out int deptId) ||
                    !departments.Exists(d => d.Id == deptId))
                {
                    Console.WriteLine("Yanlish sobe ID!");
                    continue;
                }

                _repo.Add(new Employee
                {
                    Name = name,
                    Surname = surname,
                    Salary = salary,
                    DepartmentId = deptId
                });
                _repo.SaveChanges();
                Console.WriteLine("Isci elave edildi!");
            }
        }

        public void ShowAll()
        {
            var list = _context.Employees
                               .Include(e => e.Department)
                               .AsNoTracking()
                               .ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Hec bir isci yoxdur.");
                return;
            }

            foreach (var e in list)
                Console.WriteLine($"[{e.Id}] {e.Name} {e.Surname} | " +
                                  $"Maas: {e.Salary} | Sobe: {e.Department?.Name}");
        }
    }
}