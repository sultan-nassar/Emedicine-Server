using System.ComponentModel.DataAnnotations;

namespace emedicine_api.Models
{
    public class Cart
    {
        public int ID { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Type { get; set; }

        [Required]
        public int Quantity { get; set; } = 1; 
        
    }
}
