

namespace BlazingPizza.UseCases.GetToppings;
internal sealed class GetToppingsInteractor : IGetToppingsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetToppingsInteractor(IBlazingPizzaQueriesRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Repository.GetToppingsAsync();
    }
}
