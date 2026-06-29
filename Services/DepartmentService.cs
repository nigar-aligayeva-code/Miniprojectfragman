using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniProject2.DAL;
using MiniProject2.Entities;
using MiniProject2.Repositories;

namespace MiniProject2.Services
{
    public class DepartmentService
    {
        private readonly Repository<Department> _repo;
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
            _repo = new Repository<Department>(context);
        }

        public void Add()
        {
            while (true)
            {
                Console.Write("Sobenin adi (0 - menu): ");
                string name = Console.ReadLine();

                if (name == "0") return;

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Ad bos ola bilmez!");
                    continue;
                }

                _repo.Add(new Department { Name = name });
                _repo.SaveChanges();
                Console.WriteLine("Sobe elave edildi!");
            }
        }

        public void ShowAll()
        {
            var list = _context.Departments
                               .Include(d => d.Employees)
                               .AsNoTracking()
                               .ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("Hec bir sobe yoxdur.");
                return;
            }

            foreach (var d in list)
                Console.WriteLine($"[{d.Id}] {d.Name} - {d.Employees.Count} isci");
        }

        public List<Department> GetAll()
        {
            return _context.Departments.AsNoTracking().ToList();
        }
    }
}