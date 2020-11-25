using AutoMapper;
using TourAggregator.Api.Models.v1;
using TourAggregator.Domain;

namespace OrderApi.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TourModel, Tour>();
            //.ForMember(x => x.Id, opt => opt.MapFrom(src => 1));
        }
    }
}