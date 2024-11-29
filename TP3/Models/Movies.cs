using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Movies
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        // Foreign key for Genre
        [ForeignKey("Genre")]
        public int GenresId { get; set; }

        [NotMapped]
        public Genres Genre { get; set; }


        // Many-to-many relationship with Customers
        public ICollection<Customers> Customers { get; set; }
    }
}
