namespace BlazingPizza.EFCore.Repositories.Interfaces;

// Se crea esta interfaz para que solo el contexto sea visto desde el repositorio
internal interface IBlazingPizzaCommandsContext
{
    internal DbSet<EFEntities.Order> Orders { get; set; }

    internal Task<int> SaveChangesAsync();
}
