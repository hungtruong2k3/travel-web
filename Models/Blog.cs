using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Btl.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [Required]
        [StringLength(50)]
        public string BlogName { get; set; }
       
        public string BlogDescription { get; set; }
        [Required] 
        public string BlogImage { get; set; }

    }
}
