using System.Linq.Expressions;

namespace TicketBookingSystem.Data.Abstraction
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        T? Find(int id);
        T? FirstOrDefault(Expression<Func<T, bool>> whereCondition);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Edit(T entity);
        void EditRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        bool Save();
        Task<bool> SaveAsync();
    }
}
