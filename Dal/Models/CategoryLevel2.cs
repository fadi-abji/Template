using System.ComponentModel.DataAnnotations;

namespace Dal
{
    public class CategoryLevel2
    {
        [Key]
        int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public virtual ICollection<CategoryLevel3> CategoryLevel3 { get; set; }
    }
}
