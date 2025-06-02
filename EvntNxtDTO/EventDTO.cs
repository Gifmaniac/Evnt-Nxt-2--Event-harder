namespace EvntNxt.DTO
{
    public class EventDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int OrganizerID { get; set; }
        public OrganizerDTO Organizer { get; set; }
        public string Province { get; set; }
        public DateOnly Date { get; set; }
        public List<GenreDTO> Genres { get; set; } = new();
    }
}
