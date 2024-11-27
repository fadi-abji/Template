using System.ComponentModel.DataAnnotations;

namespace Dal
{
    public class MovieMedia
    {
        [Key]
        public int Id { get; set; }
        public Guid MediaUid { get; set; }
        public int MovieId { get; set; }
        public Media Media { get; set; } = null;
        public Movie Movie { get; set; } = null;
    }
}
