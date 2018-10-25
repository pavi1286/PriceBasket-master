using System.Collections.Generic;
using CartCalculator.Entities;

namespace CartCalculator
{
    /// <summary>
    /// interfcae to access the methods in DataManager class
    /// </summary>
	public interface IDataManager
	{
		IList<Product> GetProducts();
		IDiscountProcessor GetDiscountProcessor(DiscountType type);
		List<DiscountType> GetDiscountTypes();
	}
}