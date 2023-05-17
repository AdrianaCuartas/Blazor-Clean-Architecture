namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Specials;
public interface ISpecialsViewModel
{
    IReadOnlyCollection<PizzaSpecial> Specials { get; }
    Task GetSpecialsAsync();
}
