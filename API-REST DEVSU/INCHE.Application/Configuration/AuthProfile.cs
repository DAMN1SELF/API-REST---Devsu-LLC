
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

        

            // Entity -> ResponseDTO
            CreateMap<ClientEntity, ResponseAuthUserModel>()
                .ForMember(dto => dto.Token, opt => opt.Ignore())
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(entity => entity.Person.Nombres));


        }
    }
}
