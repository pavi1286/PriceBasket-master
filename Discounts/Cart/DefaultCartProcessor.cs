using System;
using System.Collections.Generic;
using System.Linq;
using CartCalculator.Entities;
using CartCalculator.Logger;

namespace CartCalculator
{
	public class DefaultCartProcessor : ICartProcessor
	{
		IList<Product> products = null; 
		IDataManager _dataManager = null;
		
        /// <summary>
        /// Default constructor to initialise product data for processing the cart 
        /// </summary>
		public DefaultCartProcessor()
		{
			_dataManager = new DataManager();
		}

		public DefaultCartProcessor(IDataManager dataManager)
		{
			_dataManager = dataManager;
		}


        /// <summary>
        /// Method to process the cart items and get the totaland discounted amount 
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        public Reciept ProcessCart(IList<string> shoppingCart)
        {
            try
            {
                //check if the products are initialised, if not set the default values.
                if (products == null)
                {
                    products = this._dataManager.GetProducts();
                }

                List<CartItem> cartitems = new List<CartItem>();
                foreach (string item in shoppingCart)
                {
                    Product itemProduct = products.SingleOrDefault(x => x.ItemName == item.Trim());

                    //check if the item is already in the cart, if available increase the quantitu and recalculate the amount. If not available, add it to the cart
                    if (cartitems.Exists(x => x.Product.ItemName == item))
                    {
                        var cartitem = cartitems.Single(x => x.Product.ItemName == item);
                        cartitem.Quantity++;
                        cartitem.CartAmount = cartitem.CartAmount + itemProduct.Price;
                    }
                    else
                    {
                        cartitems.Add(new CartItem { Product = itemProduct, CartAmount = itemProduct.Price, Quantity = 1 });
                    }
                }

                //check if there are any discount types other than NoDiscount and the discount is applied for today for processing discount on cart items
                var discountTypesInCart = cartitems.Where(x => (x.Product.Discount.Type != DiscountType.NoDiscount)
                                                                && (x.Product.Discount.ValidDuration.StartDate <= DateTime.Today)
                                                                && (x.Product.Discount.ValidDuration.EndDate >= DateTime.Today))
                                                   .Select(x => x.Product.Discount.Type);

                //if there are products with discounts apply discount
                if (discountTypesInCart.Count() > 0)
                {
                    foreach (var discounttype in discountTypesInCart)
                        _dataManager.GetDiscountProcessor(discounttype).ProcessDiscount(cartitems);
                }


                return new Reciept { ShoppingCart = cartitems };
            }
            catch (Exception ex)
            {
                //Logger.log.Error(string.Format("Error while processing cart : {0}", ex.Message.ToString()), ex);

                throw;
            }
        }
	}
}
