namespace Membership.Entities.Interfaces;

public interface IUserService
{
    bool IsAuthenticated { get; }

    string UserId { get; }

    string FullName { get; }
    void ThrowIfNotAuthenticated()
    {
        if (!IsAuthenticated)
        {
            throw new UnauthorizedAccessException();
        }
    }




}

