namespace Core.Movie.Dtos
{
    public class Movie
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public Guid Uid { get; set; }
        public string? Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public string? Rating { get; set; }
        public List<MovieMedia> MovieMedias { get; set; }
    }
}
