namespace Membership.Presenters;

internal static class JwtHelper
{
    //PArar firmar el token:
    static SigningCredentials GetSigningCredentials(
        JwtConfigurationOptions options)
    {
        var Key = Encoding.UTF8.GetBytes(
            options.SecurityKey);
        //token es simetrico
        var Secret = new SymmetricSecurityKey(Key);

        return new SigningCredentials(Secret,
            SecurityAlgorithms.HmacSha256);
    }

    //para regresar una lista de claims del usuario
    public static List<Claim> GetUserClaims(UserDto userDto) =>
    new List<Claim>
    {
                new Claim(ClaimTypes.Name, userDto.Email),
                new Claim("FullName", $"{userDto.FirstName} {userDto.LastName}".Trim())

    };


    //devuelve un token de seguridad representando un JWT
    static JwtSecurityToken GetJwtSecurityToken(
        JwtConfigurationOptions options,
        SigningCredentials signingCredentials, List<Claim> userClaims) =>
        new JwtSecurityToken(
            issuer: options.ValidIssuer, //quien emite el token.
            audience: options.ValidAudience,
            claims: userClaims,
            expires: DateTime.Now.AddMinutes(
                options.ExpireInMinutes),
            signingCredentials: signingCredentials);

    public static List<Claim> GetUserClaimsFromToken(string accessToken)
    {
        var Handler = new JwtSecurityTokenHandler();
        var Token = Handler.ReadJwtToken(accessToken);

        return Token.Claims.Where(c => c.Type == "FullName" || c.Type == ClaimTypes.Name).ToList();

    }

    public static string GetAccessToken(JwtConfigurationOptions options,
        List<Claim> userClaims)
    {
        //obterner la credenciales para firmar el token
        SigningCredentials SigningCredentials =
            GetSigningCredentials(options);


        //para obtener las opciones del token:
        JwtSecurityToken JwtSecurityToken =
            GetJwtSecurityToken(options, SigningCredentials, userClaims);

        return new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);
    }
}
