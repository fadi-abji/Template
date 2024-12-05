using System.ComponentModel.DataAnnotations;

namespace Dal
{
    public class CategoryLevel1
    {
        [Key]
        int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public virtual ICollection<CategoryLevel2> CategoryLevel2 { get; set; }
    }
}
