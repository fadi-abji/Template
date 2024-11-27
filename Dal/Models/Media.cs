using System.ComponentModel.DataAnnotations;

namespace Dal
{
    public class Media
    {
        [Key]
        public Guid Uid { get; set; }
        public int MediaTypeId { get; set; }
        public MediaType MediaType { get; set; } = null!;
        public string? Description { get; set; }
        // null! means? I acknowledge that this property is not initialized yet, but it will not be null when used
        public string Name { get; set; } = null!;
        public string? AlternateText { get; set; }
        public string FileName { get; set; } = null!;
        public string OriginalFilename { get; set; } = null!;
        public int? Width { get; set; }
        public int? Height { get; set; }
        public virtual ICollection<MovieMedia> MovieMedias { get; set; } = null!;
    }
}
