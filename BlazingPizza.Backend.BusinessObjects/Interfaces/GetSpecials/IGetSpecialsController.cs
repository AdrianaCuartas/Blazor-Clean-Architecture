namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetSpecials;
public interface IGetSpecialsController
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
