namespace Membership.Entities.Interfaces;
//al inicio de sesion del usuario obtiene el accesstoken y el refreshtoken
public interface IRefreshTokenManager
{
    //iniciar sesion: generar nuevo  refresh token: se necesita  informacion para devolver el 
    //refreshtoken y se obtiene del accesstoken para saber de quien es  el refresh token
    Task<string> GetNewTokenAsync(string accessToken);

    //cerrar sesion
    Task DeleteTokenAsync(string refreshToken);

    Task ThrowIfNotCanGetNewTokenAsync(string refreshToken, string accessToken);

    //refrescar token
    // Task<string> RotateTokenAsync(string userName, string refreshToken);



}
