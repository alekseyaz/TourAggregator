using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TourAggregator.Data.Repository.v1;
using TourAggregator.Domain;

namespace OrderApi.Service.v1.Query
{
    public class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, Tour>
    {
        private readonly ITourRepository _tourRepository;

        public GetTourByIdQueryHandler(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<Tour> Handle(GetTourByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tourRepository.GetTourByIdAsync(request.Id, cancellationToken);
        }
    }
}