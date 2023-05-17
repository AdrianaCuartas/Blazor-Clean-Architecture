namespace BlazingPizza.EFCore.Repositories.Interfaces;

// Se crea esta interfaz para que solo el contexto sea visto desde el repositorio

public interface IBlazingPizzaQueriesContext
{
    internal DbSet<EFEntities.PizzaSpecial> Specials { get; set; }
    internal DbSet<EFEntities.Topping> Toppings { get; set; }
    internal DbSet<EFEntities.Order> Orders { get; set; }
}
