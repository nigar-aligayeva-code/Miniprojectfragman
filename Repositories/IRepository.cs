using System.Collections.Generic;

namespace MiniProject2.Repositories
{
    // public olaraq saxlayırıq
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);
        List<T> GetAll();
        T? GetById(int id, bool isTracking = false); // Müəllimdəki isTracking parametrini əlavə etdik         
        int SaveChanges();
    }
}