
namespace BlazingPizza.UseCases.GetSpecials;
internal sealed class GetSpecialsInteractor : IGetSpecialsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetSpecialsInteractor(IBlazingPizzaQueriesRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        var Result = await Repository.GetSpecialsAsync();
        return Result.OrderByDescending(s => s.BasePrice).ToList();
    }
}
