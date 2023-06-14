using Membership.Entities.Dtos;

namespace Membership.Entities.Interfaces.Login;

public interface ILoginInputPort
{
    Task LoginAsync(LocalUserCredentialsDto userCredentials);
}
