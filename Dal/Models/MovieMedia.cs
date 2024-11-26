using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class MovieMedia
    {
        [Key]
        public Guid MediaUid { get; set; }
        public int MovieId { get; set; }
        public Media Media { get; set; } = null;
        public Movie Movie { get; set; } = null;
    }
}
