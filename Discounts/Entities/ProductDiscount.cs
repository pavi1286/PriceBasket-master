using System;

namespace CartCalculator.Entities
{
    //porperties for discount type for product
    public class ProductDiscount
	{
		public DiscountType Type { get; set; }
		public float DiscountPercentage { get; set; }
		public int MultibuyDiscountQuantity { get; set; }
		public Product MultibuyTargetProduct { get; set; }
		public string DiscountText { get; set; }
        public Duration ValidDuration { get; set; }
	}

    public class Duration
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
