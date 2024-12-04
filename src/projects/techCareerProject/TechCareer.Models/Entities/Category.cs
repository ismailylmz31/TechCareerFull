



using Core.Persistence.Repositories.Entities;

namespace TechCareer.Models.Entities;

public class Category : Entity<int>
{
    public object Event;

    public string Name { get; set; }

    // Navigation Property
    public ICollection<Event> Events { get; set; } = new List<Event>();

}