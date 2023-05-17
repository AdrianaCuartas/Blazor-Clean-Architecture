namespace BlazingPizza.Shared.Validators.Address;
internal class AddressSpecification :
    Specification<BusinessObjects.ValueObjects.Address>
{
    public AddressSpecification()
    {
        Property(a => a.Name)
       .AddRule(
           a => !string.IsNullOrWhiteSpace(a.Name),
           "Debe especificar el nombre");

        Property(a => a.AddressLine1)
       .AddRule(
           a => !string.IsNullOrWhiteSpace(a.AddressLine1),
           "Debe especificar la dirección");

        //Property(a => a.PostalCode)
        //.AddRule(
        //  a => !string.IsNullOrWhiteSpace(a.PostalCode),
        //  "Debe especificar el código postal")
        //  .AddRule(a => a.PostalCode.Length == 5,
        //  "El código postal debe ser de 5 caracteres");

        //en colombia el codigo posta es de 6 digitos
        Property(a => a.PostalCode)
       .AddRule(
         a => !string.IsNullOrWhiteSpace(a.PostalCode),
         "Debe especificar el código postal")
         .AddRule(a => a.PostalCode.Length == 6,
         "El código postal debe ser de 6 caracteres");
    }
}