namespace OrdersService.Api.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
