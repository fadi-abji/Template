using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class Media
    {
        [Key]
        public Guid Uid { get; set; }
        public ICollection<MovieMedia> MovieMedias { get; set; } = null;
    }
}
