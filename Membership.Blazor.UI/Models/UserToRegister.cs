using System.ComponentModel.DataAnnotations;

namespace Membership.Blazor.UI.Models;

internal class UserToRegister
{
    [Required(ErrorMessage = "El nombre es requerido.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "El apellido es requerido.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "El correo es requerido.")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida.")]
    [Compare("ConfirmPassword", ErrorMessage = "La contraseña y la confirmación no coinciden")]
    public string Password { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida.")]
    [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden")]
    public string ConfirmPassword { get; set; }
}
