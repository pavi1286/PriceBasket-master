using CartCalculator.Discount;
using CartCalculator.Entities;
using System;
using System.Collections.Generic;

namespace CartCalculator
{
    /// <summary>
    /// class to initialise products and discounts
    /// </summary>
    public class DataManager : IDataManager
	{
		public IList<Product> GetProducts()
		{
			List<Product> _productList = new List<Product>();
            _productList.Add(new Product
            {
                ItemId = 1,
                ItemName = "Soup",
                Price = .65,
                UnitofMeasure = "tin",
                Discount = new ProductDiscount
                {
                    Type = DiscountType.MultiBuyDiscountOnOtherProducts,
                    MultibuyDiscountQuantity = 2,
                    MultibuyTargetProduct = new Product
                    {
                        ItemId = 2,
                        ItemName = "Bread",
                        Price = .80,
                        UnitofMeasure = "loaf",
                        Discount = new ProductDiscount { Type = DiscountType.NoDiscount }
                    },
                    DiscountPercentage = 50,
                    DiscountText = "Bread at half price for 2 tins of Soup",
                    ValidDuration = new Duration { StartDate = new DateTime(2018, 10, 21), EndDate = new DateTime(2018, 11, 10) }
                }
            });// Bread at half price for 2 tins of Soup

            _productList.Add(new Product
            {
                ItemId = 2,
                ItemName = "Bread",
                Price = .80,
                UnitofMeasure = "loaf",
                Discount = new ProductDiscount { Type = DiscountType.NoDiscount }
            });

            _productList.Add(new Product
            {
                ItemId = 3,
                ItemName = "Milk",
                Price = 1.3,
                UnitofMeasure = "bottle",
                Discount = new ProductDiscount { Type = DiscountType.NoDiscount }
            });

            _productList.Add(new Product
            {
                ItemId = 4,
                ItemName = "Apples",
                Price = 1,
                UnitofMeasure = "bag",
                Discount = new ProductDiscount
                {
                    Type = DiscountType.PercentageOfCartPrice,
                    DiscountPercentage = 10.00f,
                    DiscountText = "10% Off on Cart Price",
                    ValidDuration = new Duration { StartDate = new DateTime(2018, 10, 21), EndDate = new DateTime(2018, 10, 27) }
                }
            });//10% Off on Cart Price

			return _productList;
		}

        /// <summary>
        /// method to check for the discount type and invoke the appropriate class
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
		public IDiscountProcessor GetDiscountProcessor(DiscountType type)
		{
			switch(type)
			{
				case DiscountType.PercentageOfCartPrice: return new CartPriceDiscountProcessor();
				case DiscountType.MultiBuyDiscountOnOtherProducts: return new MultibuyDiscountProcessor();
				case DiscountType.MultiBuyDiscountOnSelf: return new MultibuyDiscountProcessor();

				default:return null;
			}
		}

        //method to return the list of discount types
		public List<DiscountType> GetDiscountTypes()
		{
            return new List<DiscountType>() { DiscountType.MultiBuyDiscountOnOtherProducts, DiscountType.MultiBuyDiscountOnSelf, DiscountType.PercentageOfCartPrice };
		}
	}
}
