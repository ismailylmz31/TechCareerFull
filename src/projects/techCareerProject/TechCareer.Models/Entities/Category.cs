using Core.Persistence.Repositories.Entities;
using TechCareer.Models.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }

    // Navigation Property
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
