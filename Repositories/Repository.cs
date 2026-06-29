using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MiniProject2.DAL;

namespace MiniProject2.Repositories
{
    // Program.cs-in rahat oxuması üçün bunu da public edirik
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
        }

        public List<T> GetAll()
        {
            return _table.AsNoTracking().ToList();
        }

        // Müəllimin ekrandakı tam kod blokunu bura tətbiq etdik (image_afdb52.jpg)
        public T? GetById(int id, bool isTracking = false)
        {
            if (isTracking)
            {
                return _table.FirstOrDefault(s => EF.Property<int>(s, "Id") == id);
            }

            return _table.AsNoTracking().FirstOrDefault(s => EF.Property<int>(s, "Id") == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}