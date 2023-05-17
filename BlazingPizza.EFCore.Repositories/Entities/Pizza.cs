namespace BlazingPizza.EFCore.Repositories.Entities;
class Pizza
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int PizzaSpecialId { get; set; }
    public PizzaSpecial PizzaSpecial { get; set; }
    public int Size { get; set; }
    public List<PizzaTopping> Toppings { get; set; }
}
