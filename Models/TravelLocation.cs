using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Btl.Models
{
    public class TravelLocation
    {
        [Key] public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        [Required]
        public string LocationImage { get; set; }

    }
}
