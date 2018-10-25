using System;

namespace CartCalculator.Entities
{
    //properties of each product
    public class Product
    {
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public Double Price { get; set; }
        public String UnitofMeasure { get; set; }
        public ProductDiscount Discount { get; set; }

    }
}
