using System.Collections.Generic;

namespace IT3047C_FinalProject.Models
{
    public class RecommendationEditViewModel
    {
        public int RecommendationId { get; set; }
        public List<RecommendationItemUpdateModel> Items { get; set; } = new List<RecommendationItemUpdateModel>();
    }

    public class RecommendationItemUpdateModel
    {
        public int RecommendationItemId { get; set; }
        public int Quantity { get; set; }
    }
}