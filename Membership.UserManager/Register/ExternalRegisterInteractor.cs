using Membership.Entities.Dtos;
using System.Text;

namespace Membership.UserManager.Register;

internal class ExternalRegisterInteractor : IExternalRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public ExternalRegisterInteractor(IUserManagerService userManagerService)
    {
        UserManagerService = userManagerService;
    }

    public async Task RegisterAsync(ExternalUserForRegistrationDto user)
    {
        await UserManagerService.ThrowIfUnableToRegisterAsync(
            new UserForRegistrationDto
            {
                UserName = $"{user.Provider}-{user.UserId}",
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = GetRandomPassword() //Aspnet.identity exige un password rigido, que no sea nulo

            }); ;
    }

    string GetRandomPassword()
    {
        byte[] PasswordBytes = new byte[20];
        PasswordBytes[0] = GetRandomByteFromRange(65, 91); //letra mayuscula
        PasswordBytes[1] = GetRandomByteFromRange(97, 123); //letra minuscula
        PasswordBytes[2] = GetRandomByteFromRange(33, 48); //caracter especial
        PasswordBytes[3] = GetRandomByteFromRange(48, 58); //numero
        for (int i = 4; i < 20; i++)
            PasswordBytes[i] = GetRandomByteFromRange(33, 127);

        //var R = new Random();
        //PasswordBytes[0] = (byte)R.Next(65, 91);
        //PasswordBytes[1] = (byte)R.Next(97, 123);
        //for (int i = 2; i < 8; i++)
        //{
        //    PasswordBytes[i] = (byte)R.Next(33, 48);
        //}
        //for (int i = 8; i < 14; i++)
        //{
        //    PasswordBytes[i] = (byte)R.Next(48, 58);
        //}
        return Encoding.UTF8.GetString(PasswordBytes);
    }

    byte GetRandomByteFromRange(int inclusive, int exclusive) =>
        (byte)new Random().Next(inclusive, exclusive);

}
