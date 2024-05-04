namespace mshop.sharedkernel.messaging.Data.Response.Orders
{
    public class OrderResponse
    {
        public string? Id { get; set; }
        public string? ClientEmail { get; set; }
        public List<string>? IdProducts { get; set; }
        public decimal? TotalPriceBeforeDiscount { get; set; }
        public decimal? TotalPriceAfterDiscount { get; set; }
        public decimal? DiscountPercentage { get; set; }
    }
}
