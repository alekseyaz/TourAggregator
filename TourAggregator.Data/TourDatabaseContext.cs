using Microsoft.EntityFrameworkCore;
using TourAggregator.Domain;

namespace TourAggregator.Data
{
    public partial class TourDatabaseContext : DbContext
    {
        public TourDatabaseContext()
        {
        }

        public TourDatabaseContext(DbContextOptions<TourDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<TourProvider> TourProviders { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.YearBuilt).HasColumnType("date");
            });

            modelBuilder.Entity<TourProvider>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DateArrival).HasColumnType("date");

                entity.Property(e => e.DateDeparture).HasColumnType("date");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.PricePerNight).HasColumnType("money");

                entity.Property(e => e.TourProviderId).HasColumnName("TourProviderID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Tours_Citys");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Tours_Countrys");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Tours_Hotels");

                entity.HasOne(d => d.TourProvider)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.TourProviderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Tours_TourProviders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
