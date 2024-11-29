using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class Genres
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string GenreName { get; set; }


        public ICollection<Movies> Movies { get; set; }
    }
}
