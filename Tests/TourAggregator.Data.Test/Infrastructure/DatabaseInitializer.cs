using System;
using System.Collections.Generic;
using System.Linq;
using TourAggregator.Domain;

namespace TourAggregator.Data.Test.Infrastructure
{
    public class DatabaseInitializer
    {
        public static void Initialize(TourDatabaseContext context)
        {
            if (context.Tours.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(TourDatabaseContext context)
        {
            var tours = new List<Tour>();

            tours.Add(new Tour
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
            });

            context.Tours.AddRange(tours);
            context.SaveChanges();
        }
    }
}