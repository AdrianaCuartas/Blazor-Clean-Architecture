namespace BlazingPizza.Shared.BusinessObjects.Dtos;
public record class PizzaDto(
    PizzaSpecial Special,
    int Size,
    IReadOnlyCollection<Topping> Toppings)
{
    public decimal GetBasePrice() =>
        (decimal)Size / (decimal)PizzaSize.Default * Special.BasePrice;
    public decimal GetTotalPrice() =>
        GetBasePrice() + Toppings.Sum(t => t.Price);
    public string GetFormattedTotalPrice() =>
        GetTotalPrice().ToString("$ #,###.##");
}
