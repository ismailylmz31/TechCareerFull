using Core.Persistence.Repositories.Entities;
using TechCareer.Models.Entities;

public class Category : Entity<int>
{
    public string? Name { get; set; }  
    public ICollection<Event>? Events { get; set; } 
}
