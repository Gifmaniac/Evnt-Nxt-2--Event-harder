

namespace EvntNxt.DTO
{
    public class EventWithOrganizerAndGenreDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public string Province { get; set; }

        public OrganizerDTO Organizer { get; set; }
        public List<GenreDTO> Genre { get; set; } = new();
    }
}
