namespace mshop.sharedkernel.messaging.Data.Request.Products
{
    public record GetProductsByIdsRequest(IEnumerable<Guid> ids);
}
