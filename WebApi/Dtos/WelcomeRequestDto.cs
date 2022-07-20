using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class WelcomeRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}