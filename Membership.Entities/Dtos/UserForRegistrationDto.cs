namespace Membership.Entities.Dtos;
public record struct UserForRegistrationDto(
      string UserName,
       string Email, string Password,
    string FirstName, string LastName);
