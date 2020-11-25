using System.ComponentModel.DataAnnotations;

namespace TourAggregator.Api.Models.v1
{
    public class TourModel
    {
        [Required] public int Id { get; set; }

        [Required] public int TourProviderId { get; set; }

    }
}