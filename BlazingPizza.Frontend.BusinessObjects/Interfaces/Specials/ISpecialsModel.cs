namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Specials;
public interface ISpecialsModel
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
