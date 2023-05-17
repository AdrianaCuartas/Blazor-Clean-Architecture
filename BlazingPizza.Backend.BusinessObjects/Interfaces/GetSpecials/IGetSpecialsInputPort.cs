namespace BlazingPizza.Backend.BusinessObjects.Interfaces.GetSpecials;
public interface IGetSpecialsInputPort
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
