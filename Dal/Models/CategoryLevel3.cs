using System.ComponentModel.DataAnnotations;

namespace Dal
{
    public class CategoryLevel3
    {
        [Key]
        int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}
