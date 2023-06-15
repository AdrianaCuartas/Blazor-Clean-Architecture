using Membership.Shared.Entities;

namespace BlazingPizza.Razor.Views.Pages.User;

public partial class Register
{
    [Inject]
    NavigationManager NavigationManager { get; set; }

    void OnRegister(UserForRegistrationDto newUser)
    {
        Console.WriteLine($"Usuario registrado: {newUser.FirstName}{newUser.LastName}");


        NavigationManager.NavigateTo("user/login");
    }
}
