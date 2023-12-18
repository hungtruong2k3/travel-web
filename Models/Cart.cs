
namespace Btl.Models
{
	public class Cart
	{
		public List<CartLine> Lines { get; set; } = new List<CartLine>();
		public void AddItem(Product product, int quantity ) 
		{
			CartLine? line = Lines.Where(p=>p.product.ProductId==product.ProductId).FirstOrDefault();
			if (line==null)
			{
				Lines.Add(new CartLine
				{
					product = product,
					Quantity = quantity
				});
			}
		}
		public void RemoveLine(Product product)=>Lines.RemoveAll(l=>l.product.ProductId==product.ProductId);
		public decimal ComputeTotalValues() => (decimal)Lines.Sum(e => e.product.ProductDiscount * e.Quantity);

        
	}
	public class CartLine 
	{ 
		public int CartLineID { get; set; }
		public Product product { get; set; } = new();
		public int Quantity { get; set; } 
	}
}
