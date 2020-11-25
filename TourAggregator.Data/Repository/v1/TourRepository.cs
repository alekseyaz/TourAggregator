using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TourAggregator.Domain;

namespace TourAggregator.Data.Repository.v1
{
    public class TourRepository : Repository<Tour>, ITourRepository
    {
        public TourRepository(TourDatabaseContext tourContext) : base(tourContext)
        {
        }

        public async Task<Tour> GetTourByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await TourDatabaseContext.Tours.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}