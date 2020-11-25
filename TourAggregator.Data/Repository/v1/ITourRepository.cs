using System.Threading;
using System.Threading.Tasks;
using TourAggregator.Domain;

namespace TourAggregator.Data.Repository.v1
{
    public interface ITourRepository : IRepository<Tour>
    {
        Task<Tour> GetTourByIdAsync(int id, CancellationToken cancellationToken);
    }
}