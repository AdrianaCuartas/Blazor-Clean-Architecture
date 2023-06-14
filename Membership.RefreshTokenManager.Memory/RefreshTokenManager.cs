namespace Membership.RefreshTokenManager.Memory;

internal class RefreshTokenManager : IRefreshTokenManager
{
    //almacena el refreshtoken y el token:
    readonly ConcurrentDictionary<string, Token> Tokens = new();
    readonly JwtConfigurationOptions Options;

    public RefreshTokenManager(
        IOptions<JwtConfigurationOptions> options)
    {
        Options = options.Value;
    }
    public Task DeleteTokenAsync(string refreshToken)
    {
        //elimina el refreshtoken:
        Tokens.TryRemove(refreshToken, out Token _);
        return Task.CompletedTask;
    }

    public Task ThrowIfNotCanGetNewTokenAsync(string refreshToken, string accessToken)
    {
        if (Tokens.TryGetValue(refreshToken, out Token Token))
        {
            Tokens.TryRemove(refreshToken, out Token _);
            if (Token.AccessToken != accessToken)
                throw new RefreshTokenCompromisedException(refreshToken);

            //verifica la fecha de expiracion del refreshtoken
            if (Token.ExpiresAt < DateTime.UtcNow)
                throw new RefreshTokenExpiredException(refreshToken);

        }
        else
        {
            throw new RefreshTokenNotFoundException();
        }
        return Task.CompletedTask;
    }
    public Task<string> GetNewTokenAsync(string accessToken)
    {
        string RefreshToken = GenerateToken();
        Token Token = new Token
        {
            AccessToken = accessToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(Options.RefreshTokenExpireInMinutes)
        };
        if (!Tokens.TryAdd(RefreshToken, Token))
        {
            RefreshToken = null;
        }
        return Task.FromResult(RefreshToken);
    }

    private string GenerateToken()
    {
        //6 bits => 1 caracter de una cadena base64
        //N Bytes => 100 caracteres base64
        var Buffer = new byte[75]; //100caractres *6 bits =600bits ,
        //600bits /8 => 75 BYTES

        using var Rng = RandomNumberGenerator.Create();

        Rng.GetBytes(Buffer);

        return Convert.ToBase64String(Buffer);
    }


}
