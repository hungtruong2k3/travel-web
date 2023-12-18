using System.ComponentModel.DataAnnotations;
namespace Btl.Models
{
    public class Local
    {
        [Key] public int LocalID { get; set; }
        [StringLength(50)]
        [Required] public string LocalName { get; set; }
        [StringLength(150)]
        [Required] public string LocalDescription { get;set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<FoodList>? FoodLists { get; set; }
        public ICollection<TravelLocation>? TravelLocations { get; set; }
    }
}
