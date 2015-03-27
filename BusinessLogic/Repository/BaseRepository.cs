using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DCMS.BusinessLogic.Cache;
using Remail.BusinessLogic.UnitOfWork;

namespace Remail.BusinessLogic.Repository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
	    internal DbSet<T> DbSet;

        private MemoryCacheManager _cache;
        private string _cacheKey;


        private IList<T> Data
        {
            get
            {
                return GetData();
            }
        } 

        public BaseRepository(IUnitOfWork unitOfWork)
        {
	        if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

	        DbSet = unitOfWork.Context.Set<T>();

            _cache = new MemoryCacheManager();
            _cacheKey = typeof(T).GUID.ToString();
        }

        private IList<T> GetData()
        {
            var @interface = typeof(T).GetInterface(Constants.CachableInterface);

            if (@interface != null)
            {
                return GetFromCache();
            }

            return DbSet.ToList();
        }

        private IList<T> GetFromCache()
        {
            if (!_cache.IsSet(_cacheKey))
            {
                _cache.Set(_cacheKey, GetQueryable().ToList());
            }

            return _cache.Get<IList<T>>(_cacheKey);
        }

        public T Get(Func<T, bool> predicate)
        {
            return Data.First(predicate);
        }

        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return Data.FirstOrDefault(predicate);
        }

        public IList<T> GetAll(Func<T, bool> predicate)
        {
            return Data.Where(predicate).ToList();
        }

        public IList<T> GetAll()
        {
            return Data.ToList();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
            _cache.Remove(_cacheKey);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            _cache.Remove(_cacheKey);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetQueryable()
        {
            return DbSet;
        }

        public IQueryable<T> GetList()
        {
            return DbSet;
        }

        public int Count(Func<T, bool> predicate)
        {
            return Data.Count(predicate);
        }

        public int Count()
        {
            return Data.Count();
        }


    }
}

