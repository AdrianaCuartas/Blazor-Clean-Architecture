namespace BlazingPizza.Shared.BusinessObjects.Dtos;
public class PlaceOrderPizzaDto
{
    public int PizzaSpecialId { get; set; }
    public int Size { get; set; }
    public List<int> ToppingsIds { get; set; }
}
