﻿using Membership.Entities.Dtos;

namespace Membership.Entities.Interfaces.Register;

//permite acceder al interactor
public interface IRegisterInputPort
{
    Task RegisterAsync(Shared.Entities.UserForRegistrationDto userData);
}
