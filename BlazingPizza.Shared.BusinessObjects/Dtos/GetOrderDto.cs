namespace BlazingPizza.Shared.BusinessObjects.Dtos;
public class GetOrderDto
{
    public int Id { get; init; }
    public DateTime CreatedTime { get; init; }
    public string UserId { get; init; }
    public IReadOnlyCollection<PizzaDto> Pizzas { get; init; }

    public OrderStatus Status { get; init; }

    public bool IsDelivered { get; init; }
    public LatLong DeliveryLocation { get; init; }

    public decimal GetTotalPrice() =>
        Pizzas.Sum(p => p.GetTotalPrice());
    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #,###.##");

}

