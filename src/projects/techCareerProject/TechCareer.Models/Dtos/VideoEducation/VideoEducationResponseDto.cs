using System.Reflection.Emit;
using TechCareer.Models.Entities.Enum;

namespace TechCareer.Models.Dtos.VideoEducation;

public sealed class VideoEducationResponseDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double TotalHour { get; set; }
    public Level Level { get; set; }
    public string? ImageUrl { get; set; }
    public Guid InstrutorId { get; set; }
    public string? ProgrammingLanguage { get; set; }

}
