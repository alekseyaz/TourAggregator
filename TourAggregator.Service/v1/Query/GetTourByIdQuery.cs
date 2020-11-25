using MediatR;
using System;
using TourAggregator.Domain;

namespace OrderApi.Service.v1.Query
{
    public class GetTourByIdQuery : IRequest<Tour>
    {
        public int Id { get; set; }
    }
}
