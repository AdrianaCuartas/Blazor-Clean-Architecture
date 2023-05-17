namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaMapper
{
    internal static EFEntities.Pizza ToEFPizza(
        this PlaceOrderPizzaDto pizza) =>
        new EFEntities.Pizza
        {
            PizzaSpecialId = pizza.PizzaSpecialId,
            Size = pizza.Size,
            Toppings = pizza.ToppingsIds
                .Select(id => new EFEntities.PizzaTopping
                {
                    ToppingId = id
                }).ToList()
        };

    internal static SharedAggregates.Pizza ToPizza(
        this EFEntities.Pizza pizza)
    {
        var Pizza = new SharedAggregates.Pizza(
            pizza.PizzaSpecial.ToPizzaSpecial());
        Pizza.SetSize(pizza.Size);
        //if (pizza.Toppings != null)
        //{
        //    foreach (var PizzaTopping in pizza.Toppings)
        //    {
        //        Pizza.AddTopping(PizzaTopping.Topping.ToTopping());
        //    }
        //}
        pizza.Toppings?
            .ForEach(p => Pizza.AddTopping(p.Topping.ToTopping()));
        return Pizza;
    }
}
