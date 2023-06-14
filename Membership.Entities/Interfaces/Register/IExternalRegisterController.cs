namespace Membership.Entities.Interfaces.Register;

public interface IExternalRegisterController
{

    Task RegisterAsync(ExternalUserForRegistrationDto userData);

}
