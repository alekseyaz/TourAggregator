using Microsoft.EntityFrameworkCore;
using System;

namespace TourAggregator.Data.Test.Infrastructure
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly TourDatabaseContext Context;

        public DatabaseTestBase()
        {
            var options = new DbContextOptionsBuilder<TourDatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            Context = new TourDatabaseContext(options);

            Context.Database.EnsureCreated();

            DatabaseInitializer.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}