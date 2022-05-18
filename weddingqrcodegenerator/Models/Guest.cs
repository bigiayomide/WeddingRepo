using System.ComponentModel.DataAnnotations;

namespace weddingqrcodegenerator.Models
{
    public class Guest
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}