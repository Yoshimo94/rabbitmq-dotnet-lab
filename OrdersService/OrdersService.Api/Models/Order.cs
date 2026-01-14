namespace OrdersService.Api.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
