using System.ComponentModel.DataAnnotations;

namespace IT3047C_FinalProject.Models
{
    public class Gear
    {
        public int GearId { get; set; }

        [Required]
        [Display(Name = "Gear Name")]
        public string GearName { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage="Please enter a valid weight.")]
        public double Weight { get; set; }
        [Required]
        [Range(1, 5000, ErrorMessage = "Please enter a valid cost.")]
        public double Cost { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Please enter a valid quantity.")]
        [Display(Name = "Recommended Quantity")]
        public int RecommendedQuantity { get; set; }
    }
}
