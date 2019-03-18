using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kuzey.Models.Entities
{
    [Table("Products")]
    public class Product : BaseEntity<string>
    {
        [Required, StringLength(50)]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
