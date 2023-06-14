namespace Membership.Shared.Entities;
public record struct ExternalUserForRegistrationDto(

    string Provider, string UserId, string Email,
    string FirstName, string LastName);
