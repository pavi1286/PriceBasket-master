using CartCalculator.Entities;
using System.Collections.Generic;

namespace CartCalculator
{
    //interface to access the methods od DiscountProcessor class
    public interface IDiscountProcessor
	{
		void ProcessDiscount(List<CartItem> shoppingCart);
	}
}
