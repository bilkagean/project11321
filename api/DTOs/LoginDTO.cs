using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string userName { get; set; }
        
        [Required]
        public string Password { get; set;} 

    }
}