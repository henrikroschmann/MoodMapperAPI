using System.ComponentModel.DataAnnotations;

namespace MoodMapperAPI.Domain.Dto;

public record EntryDto(
    string Title,
    [Required]
    string Description,
    DateTime CreationDate,
    [Range(1, 5)]
    int Mood);