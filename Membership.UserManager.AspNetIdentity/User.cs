
namespace Membership.UserManager.AspNetIdentity;

internal class User : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}
