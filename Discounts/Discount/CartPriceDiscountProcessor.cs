using System;
using CartCalculator.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CartCalculator.Discount
{
    public class CartPriceDiscountProcessor : IDiscountProcessor
	{
        /// <summary>
        /// Method to calculate the discount for type PercentageOfCartPrice
        /// This method will use the Percentage amount and mutiply it by the amount in the cart
        /// </summary>
        /// <param name="shoppingCart"></param>
		public void ProcessDiscount(List<CartItem> shoppingCart)
		{
            //process all itmes in cart with this discount type and within valid date range
            foreach (CartItem item in shoppingCart.Where(x => (x.Product.Discount.Type == DiscountType.PercentageOfCartPrice)
                                                             && (x.Product.Discount.ValidDuration.StartDate <= DateTime.Today)
                                                             && (x.Product.Discount.ValidDuration.EndDate >= DateTime.Today)))
            {
                //get discount amount after percetage discount for the cart amount of that product
                item.DiscountAmount = item.CartAmount * (item.Product.Discount.DiscountPercentage / 100);
                item.DiscountText = item.Product.Discount.DiscountText;
            }
		}
	}
}
