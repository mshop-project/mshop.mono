using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mshop.sharedkernel.coredata.Orders
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string ClientEmail { get; set; } = null!;

        public List<string> IdProducts { get; set; } = null!;

        public decimal TotalPriceBeforeDiscount { get; set; }

        public decimal TotalPriceAfterDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
