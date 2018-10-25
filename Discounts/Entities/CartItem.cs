using System;

namespace CartCalculator.Entities
{
    //properties for caar items
    public class CartItem
	{
		public Product Product { get; set; }
		public Double Quantity { get; set; }
		public String DiscountText { get; set; }
		public Double CartAmount { get; set; }
		public Double DiscountAmount { get; set; }
		public Double FinalAmount { get { return CartAmount - DiscountAmount; } }
	}
}
