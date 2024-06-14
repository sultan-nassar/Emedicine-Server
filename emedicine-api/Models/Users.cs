using System.ComponentModel.DataAnnotations;

namespace emedicine_api.Models
{
    public class Users
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Email { get; set; }
        public string Fund { get; set; }
        public string Type { get; set; }        
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ActionType { get; set; }
        public string OrderDate { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlt { get; set; }
    }
}
