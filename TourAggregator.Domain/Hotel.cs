using System;
using System.Collections.Generic;

namespace TourAggregator.Domain
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime YearBuilt { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
