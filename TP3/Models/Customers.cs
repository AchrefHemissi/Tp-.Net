using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class Customers
    {
        [Key]
        public Guid Customerid { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Membership Type is required")]
        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        // Many-to-many relationship with Movies (optional)
        public ICollection<Movies> Movies { get; set; }
    }
}
