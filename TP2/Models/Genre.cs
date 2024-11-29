using System;
using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)] // Use a specific length instead of 'max'
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Movie> Movies { get; set; }
    }
}
