using CartCalculator.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CartCalculator.Discount
{
    public class MultibuyDiscountProcessor : IDiscountProcessor
	{
		public void ProcessDiscount(List<CartItem> shoppingCart)
		{
			foreach (CartItem item in shoppingCart.Where(x => x.Product.Discount.Type == DiscountType.MultiBuyDiscountOnOtherProducts))
			{
                if (item.Quantity >= item.Product.Discount.MultibuyDiscountQuantity)
                {
                    var discountTarget = item;

                    //Check if the target product details are available, if not set discountTarget to NULL
                    if (shoppingCart.Exists(x => x.Product.ItemName == item.Product.Discount.MultibuyTargetProduct.ItemName))                    
                        discountTarget = shoppingCart.Single(x => x.Product.ItemName == item.Product.Discount.MultibuyTargetProduct.ItemName);                    
                    else                    
                        discountTarget = null;
                    
                    //process discount only if target product details are available
                    if (discountTarget != null)
                    {
                        
                        int no_of_discounts = (int)(item.Quantity / item.Product.Discount.MultibuyDiscountQuantity);

                        int no_of_final_discounts = (int)discountTarget.Quantity <= no_of_discounts ? (int) discountTarget.Quantity : no_of_discounts;

                        discountTarget.DiscountAmount = discountTarget.Product.Price * no_of_final_discounts * (item.Product.Discount.DiscountPercentage / 100);
                        discountTarget.DiscountText = item.Product.Discount.DiscountText;
                    }
                }
			}
		}
	}
}
