using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourAggregator.Domain;

namespace TourAggregator.Data
{
    public class TourDatabaseContextSeed
    {
        public async Task SeedAsync(TourDatabaseContext context,
            ILogger<TourDatabaseContextSeed> logger, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;

            try
            {
                if (!context.Tours.Any())
                {
                    var tours = new List<Tour>();

                    tours.Add(new Tour
                    {
                        TourProvider = new TourProvider { Name = "Tui" },
                        Hotel = new Hotel { Name = "Плаза", Address = "Часовая улица, 28к3", YearBuilt = DateTime.Now },
                        TypeRoom = RoomType.Double,
                        City = new City { Name = "Стамбул" },
                        Country = new Country { Name = "Турция" },
                        DateDeparture = DateTime.Now,
                        DateArrival = DateTime.Now,
                        NumberNights = 1,
                        PricePerNight = 300,
                        MaximumTourists = 2
                    });

                    tours.Add(new Tour
                    {
                        TourProvider = new TourProvider { Name = "Tui" },
                        Hotel = new Hotel { Name = "Плаза", Address = "Ленинградский проспект", YearBuilt = DateTime.Now },
                        TypeRoom = RoomType.Double,
                        City = new City { Name = "Валенсия" },
                        Country = new Country { Name = "Испания" },
                        DateDeparture = DateTime.Now,
                        DateArrival = DateTime.Now,
                        NumberNights = 1,
                        PricePerNight = 200,
                        MaximumTourists = 2
                    });

                    tours.Add(new Tour
                    {
                        TourProvider = new TourProvider { Name = "Tui" },
                        Hotel = new Hotel { Name = "НоуНейм", Address = "улица Черняховского, 10", YearBuilt = DateTime.Now },
                        TypeRoom = RoomType.Double,
                        City = new City { Name = "Москва" },
                        Country = new Country { Name = "Россия" },
                        DateDeparture = DateTime.Now,
                        DateArrival = DateTime.Now,
                        NumberNights = 2,
                        PricePerNight = 150,
                        MaximumTourists = 2
                    });

                    context.Tours.AddRange(tours);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(TourDatabaseContext));

                    await SeedAsync(context, logger, retryForAvaiability);
                }
            }
        }
    }
}
