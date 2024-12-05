using katio.Data.Models;
using katio_net.Data.Models;
using System.Linq.Expressions;
namespace katio_net.Data;
public interface IRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    
    Task<TEntity> FindAsync(TId id);
    Task Update(TEntity entity);
    Task AddAsync(TEntity entity);
    Task Delete(TEntity entity);
    Task Delete(TId id);

    Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
        string includeProperties = ""
    );

}