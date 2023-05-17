
using BlazingPizza.Shared.BusinessObjects.ValueObjects;

namespace BlazingPizza.ViewModels;
internal sealed class CheckoutViewModel : ICheckoutViewModel
{
    readonly ICheckoutModel Model;
    readonly IOrderStateService OrderStateService;

    public CheckoutViewModel(ICheckoutModel model,
        IOrderStateService orderStateService)
    {
        Model = model;
        OrderStateService = orderStateService;
    }

    public bool IsSubmitting { get; private set; }

    public Order Order => OrderStateService.Order;

    public Address Address { get; private set; } = new Address();

    public Exception PlaceOrderException { get; private set; }


    public bool PlaceOrderSuccess => PlaceOrderException == null;

    //la regla de presentacion: en las vistas

    //esto ya no es necesario: porque hay un validador BlazingPizza.Shared.Validators
    //esta  validacion es una regla de negocio:
    //public bool IsValidAddress =>
    //    !string.IsNullOrWhiteSpace(Address.Name) &&
    //    !string.IsNullOrWhiteSpace(Address.AddressLine1) &&
    //    !string.IsNullOrWhiteSpace(Address.PostalCode);


    //boton realizar pedido se lanza este metodo:
    public async Task<int> PlaceOrderAsync()
    {
        int OrderId = 0;

        Order.SetDeliveryAddress(Address);

        try
        {
            OrderId = await Model.PlaceOrderAsync(Order);
            OrderStateService.ResetOrder();
        }
        catch (Exception ex)
        {

            PlaceOrderException = ex;
        }
        IsSubmitting = false;
        Address = new Address();



        IsSubmitting = false; //para que el usuario no  haga dos veces click

        return OrderId;



    }
}
