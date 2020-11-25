using System.Collections.Generic;

namespace TourAggregator.Domain
{
    public partial class TourProvider
    {
        public TourProvider()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
