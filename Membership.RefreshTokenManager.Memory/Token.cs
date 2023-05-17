namespace Membership.RefreshTokenManager.Memory;

//refreshtoken
internal class Token
{
    public string AccessToken { get; set; }

    public DateTime ExpiresAt { get; set; }
}