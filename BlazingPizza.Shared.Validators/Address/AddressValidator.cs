namespace BlazingPizza.Shared.Validators.Address;
internal class AddressValidator :
    Validator<BusinessObjects.ValueObjects.Address>
{
    public AddressValidator(
        IEnumerable<ISpecification<BusinessObjects.ValueObjects.Address>>
        specifications) :
        base(specifications)
    { }
}
