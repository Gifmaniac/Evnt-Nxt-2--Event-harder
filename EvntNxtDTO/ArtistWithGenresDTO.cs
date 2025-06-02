namespace EvntNxt.DTO
{
    public class ArtistWithGenresDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GenreDTO> Genres { get; set; } = new();
    }
}
