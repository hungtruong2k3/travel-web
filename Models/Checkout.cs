using System.ComponentModel.DataAnnotations;
namespace Btl.Models
{
    public class Checkout
    {
        [Key]
        public int CheckoutId { get; set; }
        [Required]
        public string CheckoutFistName { get; set; }
        [Required]
                                            
        public string CheckoutLastName { get; set;}
        [Required]
            
        public string CheckoutEmail { get; set;}
        [Required]
        public string CheckoutPhone { get; set;}
        public string CheckoutCity { get; set;}
        public string CheckoutCountry { get; set;}
        [Required]
        public string CheckoutAddress{ get; set;}
		public string CheckoutTotal { get; set; }


	}
}
