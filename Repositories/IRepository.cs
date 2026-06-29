using System.Collections.Generic;

namespace MiniProject2.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);
        List<T> GetAll();
        T? GetById(int id, bool isTracking = false);    
        int SaveChanges();
    }
}
