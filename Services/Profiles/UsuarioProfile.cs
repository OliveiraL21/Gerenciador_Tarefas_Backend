using AutoMapper;
using Domain.Dtos.User;
using Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<IdentityUser<int>, Usuario>().ReverseMap();
            CreateMap<Usuario, CustomIdentityUser>().ReverseMap();
            CreateMap<UserDtoUpdate, Usuario>().ReverseMap();
        }
    }
}
