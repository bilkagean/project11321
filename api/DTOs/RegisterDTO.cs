using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        [StringLength(8, MinimumLength=4)]
        public string Password { get; set; }
    }
}