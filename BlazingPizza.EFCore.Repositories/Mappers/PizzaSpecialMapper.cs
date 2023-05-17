namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaSpecialMapper
{
    internal static SharedEntities.PizzaSpecial ToPizzaSpecial(
    this EFEntities.PizzaSpecial pizzaSpecial) =>
    new SharedEntities.PizzaSpecial
    {
        Id = pizzaSpecial.Id,
        Name = pizzaSpecial.Name,
        BasePrice = pizzaSpecial.BasePrice,
        Description = pizzaSpecial.Description,
        ImageUrl = pizzaSpecial.ImageUrl
    };
}
