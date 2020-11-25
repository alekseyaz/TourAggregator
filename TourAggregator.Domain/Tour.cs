using System;

namespace TourAggregator.Domain
{
    public partial class Tour
    {
        public int Id { get; set; }
        public int? TourProviderId { get; set; }
        public int? HotelId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public RoomType TypeRoom { get; set; }
        public DateTime DateDeparture { get; set; }
        public DateTime DateArrival { get; set; }
        public int NumberNights { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaximumTourists { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual TourProvider TourProvider { get; set; }
    }
}
