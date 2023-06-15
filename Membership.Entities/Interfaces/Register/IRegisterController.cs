using Membership.Entities.Dtos;

namespace Membership.Entities.Interfaces.Register;

public interface IRegisterController
{
    Task RegisterAsync(Shared.Entities.UserForRegistrationDto userData);
}
