using Membership.Entities.Interfaces;

namespace BlazingPizza.UseCases.GetOrders;
internal sealed class GetOrdersInteractor : IGetOrdersInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;
    readonly IUserService UserService;
    public GetOrdersInteractor(IBlazingPizzaQueriesRepository repository, IUserService userService)
    {
        Repository = repository;
        UserService = userService;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        UserService.ThrowIfNotAuthenticated();


        return await Repository.GetOrdersAsync(UserService.UserId);
    }
}
