namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory :
    IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args)
    {
        //var OptionsBuilder =
        //    new DbContextOptionsBuilder<BlazingPizzaContext>();
        //OptionsBuilder.UseSqlServer(
        //    "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDB_CA");

        var ConnectionStringOptions = new ConnectionStringsOptions
        {
            BlazingPizzaDB = "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDB_CA"
        };


        return new BlazingPizzaContext(Options.Create(ConnectionStringOptions));
        //utiliza el constructor sin parametros


        // return new BlazingPizzaContext(OptionsBuilder.Options);
    }
}
