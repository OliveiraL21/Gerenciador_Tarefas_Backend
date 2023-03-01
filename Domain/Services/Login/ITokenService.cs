using Domain.Entidades;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public interface ITokenService
    {
      Token  gerarToken(CustomIdentityUser identityUser, string role);
    }
}
