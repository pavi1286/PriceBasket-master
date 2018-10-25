using System.Collections.Generic;
using CartCalculator.Discount;
using CartCalculator.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartCalculator.Test
{
    [TestClass]
	public class CartProcessorTests
	{
		[TestMethod]
		public void TestCartAggregation()
		{
			List<string> shoppingCart = new List<string>();
			shoppingCart.Add("Apples");
			shoppingCart.Add("Apples");
			shoppingCart.Add("Apples");
			ICartProcessor cartProcessor = new DefaultCartProcessor();
			var reciept = cartProcessor.ProcessCart(shoppingCart);
			Assert.AreEqual(1, reciept.ShoppingCart.Count);//To verify it has aggregated Properly
			Assert.AreEqual(3, reciept.ShoppingCart[0].Quantity);
		}

		[TestMethod]
		public void TestCartPriceDiscount()
		{
			List<Product> _productList = new List<Product>();
			_productList.Add(new Product
			{
				ItemId = 4,
				ItemName = "Apples",
				Price = 2,
				UnitofMeasure = "bag",
				Discount = new ProductDiscount { Type = DiscountType.PercentageOfCartPrice, DiscountPercentage = 20.00f, DiscountText = "20% Off on Cart Price" }
			});//10% Off on Cart Price
			
			List<string> shoppingCart = new List<string>();
			shoppingCart.Add("Apples");
			shoppingCart.Add("Apples");
			shoppingCart.Add("Apples");
			ICartProcessor cartProcessor = new DefaultCartProcessor();
			var reciept = cartProcessor.ProcessCart(shoppingCart);
			Assert.AreEqual(1, reciept.ShoppingCart.Count);//To verify it has aggregated Properly
			Assert.AreEqual(3, reciept.ShoppingCart[0].Quantity);
			Assert.AreEqual(1.2, reciept.TotalDiscount);
			Assert.AreEqual(4.8, reciept.FinalAmount);
		}
	}
}
