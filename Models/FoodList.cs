using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Btl.Models
{
    public class FoodList
    {
        [Key]
        public int FoodID { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public string FoodImage { get; set; }
        [Required]
        public string FoodDescription { get; set; }
        [Required]
        [ForeignKey("LocalID")]
        public int LocalID { get; set; }
        public Local? Local { get; set; }
    }
}
