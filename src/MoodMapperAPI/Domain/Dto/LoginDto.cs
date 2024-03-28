using System.ComponentModel.DataAnnotations;

namespace MoodMapperAPI.Domain.Dto;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}