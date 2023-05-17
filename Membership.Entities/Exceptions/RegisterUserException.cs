namespace Membership.Entities.Exceptions;
public class RegisterUserException : Exception
{
    public List<string> Errors { get; }
    public RegisterUserException() { }
    public RegisterUserException(string message) : base(message) { }

    public RegisterUserException(string message, Exception innerException) : base(message, innerException)
    { }

    public RegisterUserException(List<string> errors) : base("Error de registro de usuarios")
    {
        Errors = errors;
    }
}
