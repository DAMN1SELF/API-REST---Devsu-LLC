using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using INCHE.Application.Database.Account.Dto.Create;
using INCHE.Application.Database.Client.Dto.Auth;
using INCHE.Domain.Entities;

namespace INCHE.Application.Configuration
{
    public sealed class AuthProfile :Profile
    {
        public AuthProfile()
        {


            CreateMap<ClientEntity, ResponseAuthUserModel>()
                .ForMember(dto => dto.Token, opt => opt.Ignore())
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(entity => entity.Person.Nombres));


        }
    }
}
