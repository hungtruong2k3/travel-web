
using System.ComponentModel.DataAnnotations;
namespace Btl.Models
{
    public class Contact
    {
        [Key]
        [StringLength(50)]
        public int? IdContact { get; set; }
        [Required]
        [StringLength(100)]
        public string? ContactEmail { get; set; }
        [Required]
        [StringLength(50)]
        public string? ContactName { get; set; }
        public string? ContactDescription { get; set; }
    }
}
