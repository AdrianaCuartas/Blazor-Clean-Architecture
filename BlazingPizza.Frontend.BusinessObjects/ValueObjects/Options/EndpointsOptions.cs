namespace BlazingPizza.Frontend.BusinessObjects.ValueObjects.Options;
//frontend-4 endpoints

//patron opciones: tienes 2 reglas - debe ser un tipo referencia
//- y debe tener un constructor sin parametros
public class EndpointsOptions
{
    public const string SectionKey = "Endpoints";
    public string WebApiBaseAddress { get; set; }
    public string Specials { get; set; } = nameof(Specials);
    // para dar un valor predeteminado la propiedad sin no recibe un valor al tomar la configuracion
    // por el patron options
    public string Toppings { get; set; }
    public string PlaceOrder { get; set; }
    public string GetOrders { get; set; }
    public string GetOrder { get; set; }
}

