using System.ComponentModel.DataAnnotations;

namespace IT3047C_FinalProject.Models
{
    public class RecommendationItem
    {
        public int RecommendationItemId { get; set; }

        [Required]
        public int RecommendationId { get; set; }
        public Recommendation? Recommendation { get; set; }

        [Required]
        public int GearId { get; set; }
        public Gear? Gear { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
    }
}
