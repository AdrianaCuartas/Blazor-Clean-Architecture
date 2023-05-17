namespace BlazingPizza.EFCore.Repositories.Configurations;
internal sealed class OrderConfiguration :
    IEntityTypeConfiguration<EFEntities.Order>
{
    public void Configure(EntityTypeBuilder<EFEntities.Order> builder)
    {
        builder.OwnsOne(o => o.DeliveryLocation);
    }
}
