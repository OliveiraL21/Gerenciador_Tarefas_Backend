using Domain.Entidades;
using FluentResults;
using Microsoft.AspNet.Identity.EntityFramework;
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
      Token  gerarToken(IdentityUser<int> identityUser);
    }
}
