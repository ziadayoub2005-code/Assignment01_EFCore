using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreSystem.Models
{
    // Part B — Data Annotations Strategy
    // Mapping the entity to a custom table named "Writers"
    [Table("Writers")]
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Country { get; set; }
    }
}
