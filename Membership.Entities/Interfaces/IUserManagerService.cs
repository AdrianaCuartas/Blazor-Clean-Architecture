using Membership.Entities.Exceptions;

namespace Membership.Entities.Interfaces;

public interface IUserManagerService
{

    //El método RegisterAsync:

    // devuelve una posible lista de errores durante el registro del usuario
    //si no hay errores la lista esta nula o vacía

    Task<List<string>> RegisterAsync(UserForRegistrationDto userData);

    //El método ThrowIfUnableToRegisterAsync va a disparar una excepción
    //si no se puede registrar el usuario
    async Task ThrowIfUnableToRegisterAsync(UserForRegistrationDto userData)
    {
        var Errors = await RegisterAsync(userData);
        if (Errors != null && Errors.Any())
        {
            throw new RegisterUserException(Errors);
        }
    }
    Task<UserDto> GetUserByCredentialsAsync(LocalUserCredentialsDto userCredentials);

    //el metodo ThrowIfUnableToGetUserByCredentialsAsync va a disparar una excepción
    //si el usuario no fue encontrado
    async Task<UserDto> ThrowIfUnableToGetUserByCredentialsAsync(
        LocalUserCredentialsDto userCredentials)
    {
        var User = await GetUserByCredentialsAsync(userCredentials);
        if (User == default)
        {
            throw new LoginUserException();
        }
        return User;
    }


}
