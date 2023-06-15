using Membership.Blazor.Entities.Interfaces;
using Membership.Blazor.UI.Models;
using Membership.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Membership.Blazor.UI.Components;

public partial class RegisterComponent
{
    [Inject]
    IUserWebApiGateway Gateway { get; set; }


    [Parameter]
    public EventCallback<UserForRegistrationDto> OnRegister { get; set; }

    UserToRegister User = new();

    async Task Register()
    {
        UserForRegistrationDto NewUser = new UserForRegistrationDto(User.UserName,
            User.Password, User.FirstName, User.LastName);

        await Gateway.RegisterUserAsync(NewUser);
        await OnRegister.InvokeAsync(NewUser);
    }
}
