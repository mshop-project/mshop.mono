using mshop.sharedkernel.messaging.Data.Response.Categories;

namespace mshop.sharedkernel.messaging.Data.Response.Products
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public CategoryResponse Category { get; set; } = null!;
    }
}
