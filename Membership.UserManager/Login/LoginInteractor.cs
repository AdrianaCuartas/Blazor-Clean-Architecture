using Membership.Entities.Dtos;
using Membership.Entities.Interfaces;
using Membership.Entities.Interfaces.Login;

namespace Membership.UserManager.Login;

internal class LoginInteractor : ILoginInputPort
{
    readonly IUserManagerService UserManagerService;
    readonly ILoginPresenter Presenter; //es el outputpor para el interactor 

    public LoginInteractor(IUserManagerService userManagerService,
        ILoginPresenter presenter)
    {
        UserManagerService = userManagerService;
        Presenter = presenter;
    }

    public async Task LoginAsync(UserCredentialsDto userCredentials)
    {
        var User = await UserManagerService.ThrowIfUnableToGetUserByCredentialsAsync(userCredentials);
        //busca el usuario y se lo da al presentador
        await Presenter.HandleUserDataAsync(User);
    }
}
