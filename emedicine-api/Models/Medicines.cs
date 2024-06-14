using System.ComponentModel.DataAnnotations;

namespace emedicine_api.Models
{
    public class Medicines
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Manufacturer { get; set; }
        [Required]
        public string UnitPrice { get; set; }
        [Required]
        public string Discount { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string ExpDate { get; set; }
        
        public string ImageUrl { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
    }
}
