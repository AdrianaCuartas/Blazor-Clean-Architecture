namespace BlazingPizza.EFCore.Repositories.Configurations;
internal sealed class PizzaToppingConfiguration :
    IEntityTypeConfiguration<EFEntities.PizzaTopping>
{
    public void Configure(EntityTypeBuilder<EFEntities.PizzaTopping> builder)
    {
        builder.HasKey(pt => new { pt.PizzaId, pt.ToppingId });
        builder.HasOne<EFEntities.Pizza>().WithMany(p => p.Toppings);
        builder.HasOne(pt => pt.Topping)
            .WithMany();
    }
}
