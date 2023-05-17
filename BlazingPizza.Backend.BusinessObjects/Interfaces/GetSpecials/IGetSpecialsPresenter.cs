namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetSpecials;
public interface IGetSpecialsPresenter
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync(
        IReadOnlyCollection<PizzaSpecial> specials);
}
