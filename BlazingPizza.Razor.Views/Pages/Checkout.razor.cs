using ExceptionHandler.Blazor;
using Geolocation.Blazor.Geocoding;
using SpecificationValidation.Entities;
using Toast.Blazor;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    #region ..code  inyeccion
    [Inject]
    public ICheckoutViewModel ViewModel { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IValidator<Address> AddressValidator { get; set; }

    #endregion

    [Inject]
    IToastService ToastService { get; set; }

    async Task PlaceOrder()
    {
        int OrderId = await ViewModel.PlaceOrderAsync();
        if (ViewModel.PlaceOrderSuccess)
        {
            ToastService.ShowSuccess("Información", "El pedido fue registrado.");
            NavigationManager.NavigateTo($"orderdetails/{OrderId}");
        }
        else
        {
            ToastService.ShowError(ViewModel.PlaceOrderException.Message,
               ExceptionMarkupBuilder.Build(ViewModel.PlaceOrderException), 0);
        }

    }
    void SetAddress(GeocodingAddress address)
    {
        ViewModel.Address.AddressLine1 = address.AddressLine1;
        ViewModel.Address.AddressLine2 = address.AddressLine2;
        ViewModel.Address.Region = address.State;
        ViewModel.Address.City = address.City;
        ViewModel.Address.PostalCode = address.PostalCode;
        ViewModel.Order.SetDeliveryLocation(
            new LatLong(address.Latitude, address.Longitude));
    }

}
