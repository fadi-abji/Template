using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class Media
    {
        [Key]
        public Guid Uid { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
        public string? AlternateText { get; set; }
        public string FileName { get; set; } = null!;
        public string OriginalFilename { get; set; } = null!;
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
