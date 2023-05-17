
using Membership.Entities.Interfaces;

namespace BlazingPizza.UseCases.PlaceOrder;
internal sealed class PlaceOrderInteractor : IPlaceOrderInputPort
{

    readonly IBlazingPizzaCommandsRepository Repository;
    readonly IValidator<Address> AddressValidator;
    readonly IUserService UserService;
    public PlaceOrderInteractor(IBlazingPizzaCommandsRepository repository,
        IValidator<Address> addressValidator, IUserService userService)
    {
        Repository = repository;
        AddressValidator = addressValidator;
        UserService = userService;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        UserService.ThrowIfNotAuthenticated();

        order.UserId = UserService.UserId;

        AddressValidator.Guard(order.DeliveryAddress);

        //se cambia por el guard:
        //var ValidationResult = AddressValidator.Validate(order.DeliveryAddress);
        //if (!ValidationResult.IsValid)
        //    throw new Exception(ValidationResult.ToString());


        return await Repository.PlaceOrderAsync(order);

    }
}
