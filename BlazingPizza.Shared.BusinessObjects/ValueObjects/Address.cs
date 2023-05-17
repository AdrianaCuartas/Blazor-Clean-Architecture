namespace BlazingPizza.Shared.BusinessObjects.ValueObjects;

//los records son inmutables:
//el record Class permite constructores predeterminados. pero no crea de forma
//predeterminada el constructor parameterleess

//record struct inicializa los fields con los valores predeterminados
//y crea de forma predeterminada el constructor predeterminado
//public record struct Address(
//    string Name, string AddressLine1, string AddressLine2,
//    string City, string Region, string PostalCode
//    );

//value objects tiene caracteristica que no tienen identidad, y son inumutables

//pero en este caso este value object es mutable, necesitamos que los 
//valores  cambien despues de inicializado en el que lo contiene.  no en el constructor del que lo contiene Order

public class Address
{
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }

}



