using System;
using System.Collections.Generic;

namespace CartCalculator.Entities
{
    //properties for a receipt
    public class Reciept
	{
		public List<CartItem> ShoppingCart { get; set; }
		public Double CartAmount
		{
			get
			{
				double amount = 0;
				foreach(var item in ShoppingCart)
				{
					amount += item.CartAmount;
					
				}
				return Math.Round(amount, 2);
			}
		}
		public Double TotalDiscount
		{
			get
			{
				double amount = 0;
				foreach (var item in ShoppingCart)
				{
					amount += item.DiscountAmount;

				}
				return Math.Round(amount, 2);
			}
		}
		public Double FinalAmount
		{
			get
			{
				double amount = 0;
				foreach (var item in ShoppingCart)
				{
					amount += item.FinalAmount;

				}
				return Math.Round(amount,2);
			}
		}
	}
}
