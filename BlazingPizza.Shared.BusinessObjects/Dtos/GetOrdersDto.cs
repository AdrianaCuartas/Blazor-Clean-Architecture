namespace BlazingPizza.Shared.BusinessObjects.Dtos;
public record class GetOrdersDto(
    int Id, DateTime CreatedTime, string UserId,
    int PizzasCount, decimal TotalPrice, OrderStatus Status, bool IsDelivered)
{
    public string GetFormattedTotalPrice() =>
        TotalPrice.ToString("$ #,###.##");
}
