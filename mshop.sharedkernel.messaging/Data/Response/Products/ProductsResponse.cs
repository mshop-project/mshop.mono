using mshop.sharedkernel.coredata.Products;

namespace mshop.sharedkernel.messaging.Data.Response.Products
{
    public class ProductsResponse
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
