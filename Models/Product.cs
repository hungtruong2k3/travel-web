using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Btl.Models

{
    public class Product
    {
        [Key] public int? ProductId { get; set; }
        [StringLength(50)]
        [Required] public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductDiscount { get; set; }
        [StringLength(500)]
        [Required] public string? ProductDescription { get; set; }
        [StringLength(50)]
        public string? ProductImage { get; set; }
        [ForeignKey("LocalID")]
        public int LocalID { get; set; }
        public Local? Local { get; set; }
    }
}
