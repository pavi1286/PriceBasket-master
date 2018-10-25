using CartCalculator;
using CartCalculator.Entities;
using CartCalculator.Logger;
using System;


namespace PriceBasket
{
    class Program
    {
        static void Main(string[] args)
		{
            try
            {
                ICartProcessor cartProcessor = new DefaultCartProcessor();
                var reciept = cartProcessor.ProcessCart(args);
                FormatRecieptForDisplay(reciept);

            }
            catch (Exception ex)
            {
                Logger.log.Error(string.Format("Error while processing cart : {0}", ex.Message.ToString()), ex);
                Console.WriteLine("Error in processing data");
            }
		}

		private static void FormatRecieptForDisplay(Reciept reciept)
		{
            try
            {
                //additional information in the output for better understanding
                Console.WriteLine("Product	Price	Quantity	CartPrice	Discount	FinalAmount	DiscountText");
                Console.WriteLine("_____________________________________________________________________________________");
                Console.WriteLine();
                foreach (var item in reciept.ShoppingCart)
                {
                    Console.WriteLine("{0}	{1}	{2}	{3}	{4}	{5}	{6}", item.Product.ItemName,
                                        item.Product.Price,
                                        item.Quantity,
                                        item.CartAmount,
                                        item.DiscountAmount,
                                        item.FinalAmount,
                                        item.DiscountText);
                }

                Console.WriteLine();

                //Format output data in receipt in desired format
                Console.WriteLine("Sub Total: £{0}", reciept.CartAmount);
                foreach (var item in reciept.ShoppingCart)
                {
                    if (item.DiscountAmount > 0)
                    {
                        Console.WriteLine("{0} {1}: - £{2}", item.Product.ItemName, item.DiscountText, item.DiscountAmount);
                    }
                    if (!(reciept.TotalDiscount > 0))
                    {
                        Console.WriteLine("No Offers Available");
                    }

                }
                Console.WriteLine("Total: £{0}", reciept.FinalAmount);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Logger.log.Error(string.Format("Error while formatting receipt for display : {0}", ex.Message.ToString()), ex);
                throw;
            }
			
		}

	}

    
}
