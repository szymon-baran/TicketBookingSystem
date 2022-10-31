using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketBookingSystem.Data.Abstraction;
using TicketBookingSystem.Server.EntityFramework;

namespace TicketBookingSystem.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public void EditRange(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T? Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T? FirstOrDefault(Expression<Func<T, bool>> whereCondition)
        {
            return _context.Set<T>().Where(whereCondition).FirstOrDefault();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await _context.Set<T>().Where(whereCondition).FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            int result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
