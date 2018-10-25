using System.Collections.Generic;
using CartCalculator.Entities;

namespace CartCalculator
{
    /// <summary>
    /// interface for the CartProcessor
    /// </summary>
    public interface ICartProcessor
    {
		Reciept ProcessCart(IList<string> shoppingCart);   
    }
}
