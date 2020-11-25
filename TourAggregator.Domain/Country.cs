using System.Collections.Generic;

namespace TourAggregator.Domain
{
    public partial class Country
    {
        public Country()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
