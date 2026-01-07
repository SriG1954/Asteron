using AppCoreV1.Helper;
using System.Linq.Expressions;

namespace AppCoreV1.Interfaces
{
    public interface IAbleRepository<T> where T : class
    {
        Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, string>> orderby, int pageIndex, int pageSize);
        Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, int>> orderby, int pageIndex, int pageSize);
        Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, DateTime>> orderby, int pageIndex, int pageSize);
        Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> orderby, int pageIndex, int pageSize);
        Task<PaginatedList<T>> GetAll(IQueryable<T> source, int pageIndex, int pageSize);
        Task<T?> GetById(int id);
        Task<T?> GetById(string id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> DeleteById(int id);
        Task<bool> DeleteById(string id);

    }
}
