using AppCoreV1.Data;
using AppCoreV1.Helper;
using AppCoreV1.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Repositories
{
    internal class AbleRepository<T> : IAbleRepository<T> where T : class
    {
        private readonly AbleDBContext _dbContext;
        DbSet<T> dbset;

        public AbleRepository(AbleDBContext dbContext)
        {
            _dbContext = dbContext;
            dbset = dbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await dbset.AddAsync(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var item = await dbset.FindAsync(id);

                if (item == null)
                {
                    return false;
                }

                dbset.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<bool> DeleteById(string id)
        {
            try
            {
                var item = await dbset.FindAsync(id);

                if (item == null)
                {
                    return false;
                }

                dbset.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<T?> GetById(int id)
        {
            try
            {
                var item = await dbset.FindAsync(id);

                if (item == null)
                {
                    return null;
                }

                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<T?> GetById(string id)
        {
            try
            {
                var item = await dbset.FindAsync(id);

                if (item == null)
                {
                    return null;
                }

                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, string>> orderby, int pageIndex, int pageSize)
        {
            IQueryable<T> source;

            try
            {
                if (filter != null)
                {
                    source = dbset.Where(filter).OrderBy(orderby).AsNoTracking();
                }
                else
                {
                    source = dbset.OrderBy(orderby).AsNoTracking();
                }
                return await PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, int>> orderby, int pageIndex, int pageSize)
        {
            IQueryable<T> source;

            try
            {
                if (filter != null)
                {
                    source = dbset.Where(filter).OrderByDescending(orderby).AsNoTracking();
                }
                else
                {
                    source = dbset.OrderByDescending(orderby).AsNoTracking();
                }
                return await PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, DateTime>> orderby, int pageIndex, int pageSize)
        {
            IQueryable<T> source;

            try
            {
                if (filter != null)
                {
                    source = dbset.Where(filter).OrderByDescending(orderby).AsNoTracking();
                }
                else
                {
                    source = dbset.OrderByDescending(orderby).AsNoTracking();
                }
                return await PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<PaginatedList<T>> GetAll(Expression<Func<T, bool>> filter, Expression<Func<T, bool>> orderby, int pageIndex, int pageSize)
        {
            IQueryable<T> source;

            try
            {
                if (filter != null)
                {
                    source = dbset.Where(filter).OrderBy(orderby).AsNoTracking();
                }
                else
                {
                    source = dbset.OrderBy(orderby).AsNoTracking();
                }
                return await PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<PaginatedList<T>> GetAll(IQueryable<T> source, int pageIndex, int pageSize)
        {
            try
            {
                return await PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                dbset.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
