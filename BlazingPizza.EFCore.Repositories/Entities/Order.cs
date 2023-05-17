namespace BlazingPizza.EFCore.Repositories.Entities;
class Order
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public string UserId { get; set; }
    public Address DeliveryAddress { get; set; }
    public LatLong DeliveryLocation { get; set; }
    public List<Pizza> Pizzas { get; set; }
}
