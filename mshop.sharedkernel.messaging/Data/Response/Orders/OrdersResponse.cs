using mshop.sharedkernel.coredata.Orders;

namespace mshop.sharedkernel.messaging.Data.Response.Orders
{
    public class OrdersResponse
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
