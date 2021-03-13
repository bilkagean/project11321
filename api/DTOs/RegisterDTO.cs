using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}