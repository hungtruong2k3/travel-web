namespace Btl.Models
{
    public class ListModels
    {
        public IEnumerable<Btl.Models.FoodList> FoodLists { get; set; }
        public IEnumerable<Btl.Models.TravelLocation> Locations { get; set; }
        public IEnumerable<Btl.Models.Blog> Blogs { get; set; }

    }
	public class CheckoutList
	{
        public Cart cart { get; set; }
        public Checkout checkout { get; set; }
        public Product product { get; set; }    

	}
}
