namespace Membership.Shared.Entities;
public record struct UserForRegistrationDto(

    string UserName, string Password,
    string FirstName, string LastName);
