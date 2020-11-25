using FakeItEasy;
using FluentAssertions;
using System;
using TourAggregator.Data;
using TourAggregator.Data.Repository.v1;
using TourAggregator.Data.Test.Infrastructure;
using TourAggregator.Domain;
using Xunit;

namespace TourAggregatorApi.Test
{
    public class RepositoryTests : DatabaseTestBase
    {
        private readonly TourDatabaseContext _TourDatabaseContext;
        private readonly Repository<Tour> _testee;
        private readonly Repository<Tour> _testeeFake;
        private readonly Tour _newTour;

        public RepositoryTests()
        {
            _TourDatabaseContext = A.Fake<TourDatabaseContext>();
            _testeeFake = new Repository<Tour>(_TourDatabaseContext);
            _testee = new Repository<Tour>(Context);
            _newTour = new Tour
            {
                TourProvider = new TourProvider { Name = "Tui" },
                Hotel = new Hotel { Name = "Плаза", Address = "Часовая улица, 28к3", YearBuilt = DateTime.Now },
                TypeRoom = RoomType.Double,
                City = new City { Name = "Москва" },
                DateDeparture = DateTime.Now,
                DateArrival = DateTime.Now,
                NumberNights = 1,
                PricePerNight = 150,
                MaximumTourists = 2
            };
        }

        [Fact]
        public void GetAll_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _TourDatabaseContext.Set<Tour>()).Throws<Exception>();

            _testeeFake.Invoking(x => x.GetAll()).Should().Throw<Exception>().WithMessage("Couldn't retrieve entities: Exception of type 'System.Exception' was thrown.");
        }

    }
}
