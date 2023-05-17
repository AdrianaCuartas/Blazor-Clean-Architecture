namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class ToppingMapper
{
    internal static SharedEntities.Topping ToTopping(
    this EFEntities.Topping topping) =>
    new SharedEntities.Topping
    {
        Id = topping.Id,
        Name = topping.Name,
        Price = topping.Price
    };
}
