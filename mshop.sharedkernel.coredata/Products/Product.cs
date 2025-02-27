﻿namespace mshop.sharedkernel.coredata.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }

        public Category Category { get; set; } = null!;
        public Guid CategoryId { get; set; }
    }
}
