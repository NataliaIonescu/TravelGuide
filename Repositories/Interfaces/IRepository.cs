using System.Linq.Expressions;

namespace TravelGuide.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        Task<TEntity?> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool IsEmpty();
    }
}
