
namespace BlazingPizza.EFCore.Repositories.DataContexts;
// esta clase es internal para que no se exponga al exterior. hace parte de la refactorizacion
internal class BlazingPizzaContext : DbContext
{
    readonly ConnectionStringsOptions ConnectionStringOptions;

    //el contexto recibe la cadena de coneccion por inyeccion de dependencia

    public BlazingPizzaContext(IOptions<ConnectionStringsOptions> connectionStringOptions)
    {
        ConnectionStringOptions = connectionStringOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStringOptions.BlazingPizzaDB);
    }
    //public BlazingPizzaContext(DbContextOptions options) : base(options) { }

    public DbSet<EFEntities.PizzaSpecial> Specials { get; set; }
    public DbSet<EFEntities.Topping> Toppings { get; set; }
    public DbSet<EFEntities.Pizza> Pizzas { get; set; }
    public DbSet<EFEntities.Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //aplicar configuracion de un ensamblado: 
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
