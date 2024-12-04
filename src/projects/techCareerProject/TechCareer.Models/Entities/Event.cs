

using Core.Persistence.Repositories.Entities;

namespace TechCareer.Models.Entities
{
    public sealed class Event : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDeadLine { get; set; }

        public string ParticipationText { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
