

using Membership.Entities.Interfaces;

namespace BlazingPizza.UseCases.GetOrder;
internal sealed class GetOrderInteractor : IGetOrderInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;
    readonly IUserService UserService;

    public GetOrderInteractor(IBlazingPizzaQueriesRepository repository, IUserService userService)
    {
        Repository = repository;
        UserService = userService;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        UserService.ThrowIfNotAuthenticated();

        return await Repository.GetOrderAsync(id, UserService.UserId);
    }
}
