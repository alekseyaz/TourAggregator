using System;
using System.Collections.Generic;

namespace TourAggregator.Data.Repository.v1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly TourDatabaseContext TourDatabaseContext;

        public Repository(TourDatabaseContext tourContext)
        {
            TourDatabaseContext = tourContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return TourDatabaseContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}