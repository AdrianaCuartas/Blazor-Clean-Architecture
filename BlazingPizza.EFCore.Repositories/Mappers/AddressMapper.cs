namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class AddressMapper
{
    internal static EFEntities.Address ToEFAddress(
        this SharedValueObjects.Address address) =>
        new EFEntities.Address
        {
            Name = address.Name,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            Region = address.Region,
            PostalCode = address.PostalCode
        };

    internal static SharedValueObjects.Address ToAddress(
        this EFEntities.Address address) =>
        new SharedValueObjects.Address
        {
            Name = address.Name,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            Region = address.Region,
            PostalCode = address.PostalCode
        };
}
