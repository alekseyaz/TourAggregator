using System.Collections.Generic;

namespace TourAggregator.Data.Repository.v1
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();
    }
}