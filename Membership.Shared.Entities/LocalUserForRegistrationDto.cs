namespace Membership.Shared.Entities;
public record struct LocalUserForRegistrationDto(

    string Email, string Password,
    string FirstName, string LastName);
