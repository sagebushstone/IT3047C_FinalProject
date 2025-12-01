using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IT3047C_FinalProject.Models
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }

        [Required]
        public int TrailId { get; set; }
        public Trail? Trail { get; set; }

        public ICollection<RecommendationItem> Items { get; set; } = new List<RecommendationItem>();
    }
}
