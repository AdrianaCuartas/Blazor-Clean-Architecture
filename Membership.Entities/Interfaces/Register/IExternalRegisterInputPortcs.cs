namespace Membership.Entities.Interfaces.Register;

public interface IExternalRegisterInputPort
{
    Task RegisterAsync(ExternalUserForRegistrationDto user);
}
