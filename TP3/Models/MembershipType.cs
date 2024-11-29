using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        [NotMapped]
        public ICollection<Customers> Customers { get; set; }

    }
}
