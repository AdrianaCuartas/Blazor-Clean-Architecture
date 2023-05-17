
namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Checkout;
public interface ICheckoutViewModel
{
    Address Address { get; }
    bool IsSubmitting { get; }
    Order Order { get; }
    Task<int> PlaceOrderAsync();


    bool PlaceOrderSuccess { get; }
    //exponer  una excepcion para que el codebehind del componente blazor
    //sepa del mensaje de la excepcion
    Exception PlaceOrderException { get; }

}
