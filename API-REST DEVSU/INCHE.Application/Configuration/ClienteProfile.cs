using AutoMapper;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Domain.Entities;
using INCHE.Application.Database.Client.Dto.Create;
using INCHE.Application.Database.Client.Dto.Patch;
using INCHE.Application.Database.Client.Dto.Update;

namespace INCHE.Application.Configuration
{
    public sealed class ClienteProfile : Profile
    {
        public ClienteProfile()
        {


            // CreateDTO → Entity
            CreateMap<CreateClientDTO, ClienteEntity>()
                .ConstructUsing(static dto =>
                (ClienteEntity.Create(dto.NombresCliente, dto.GeneroCliente, dto.EdadCliente, dto.IdentificacionCliente,
                    dto.DireccionCliente, dto.TelefonoCliente, dto.ContrasenaHashCliente)
                ))
                .ForMember(entity => entity.PersonaId, opt => opt.Ignore())  
                .ForMember(entity => entity.Cuentas, opt => opt.Ignore());


            // UpdateDTO → Entity
            CreateMap<UpdateClientDTO, ClienteEntity>()
                .AfterMap((src, dest) =>
                {
                    dest.Update(
                        nombres: src.NombresCliente,
                        genero: src.GeneroCliente,
                        edad: src.EdadCliente,
                        identificacion: src.IdentificacionCliente,
                        direccion: src.DireccionCliente,
                        telefono: src.TelefonoCliente,
                        contrasenaHash: src.ContrasenaHashCliente
                    );
                })
                .ForAllMembers(o => o.Ignore());
            // PatchDTO → Entity
            CreateMap<PatchClientDTO, ClienteEntity>()
                .AfterMap((src, dest) =>
                {
                    dest.Patch(
                        nombres: src.NombresCliente,
                        genero: src.GeneroCliente,
                        edad: src.EdadCliente,
                        identificacion: src.IdentificacionCliente,
                        direccion: src.DireccionCliente,
                        telefono: src.TelefonoCliente,
                        contrasenaHash: src.ContrasenaHashCliente,
                        estado:src.EstadoCliente
                    );
                })
                .ForAllMembers(o => o.Ignore())
               ;

            // Entity → ResponseDTO
            CreateMap<ClienteEntity, ResponseClientDTO>()
                .ForMember(dto => dto.CodigoCliente, opt => opt.MapFrom(entity => entity.PersonaId))
                .ForMember(dto => dto.EstadoCliente, opt => opt.MapFrom(entity => entity.Estado))
                .ForMember(dto => dto.FechaRegistroCliente, opt => opt.MapFrom(entity => entity.FechaRegistro))

                .ForMember(dto => dto.NombresCliente, opt => opt.MapFrom(entity => entity.Nombres))
                .ForMember(dto => dto.GeneroCliente, opt => opt.MapFrom(entity => entity.Genero))
                .ForMember(dto => dto.EdadCliente, opt => opt.MapFrom(entity => entity.Edad))
                .ForMember(dto => dto.IdentificacionCliente, opt => opt.MapFrom(entity => entity.Identificacion))
                .ForMember(dto => dto.DireccionCliente, opt => opt.MapFrom(entity => entity.Direccion))
                .ForMember(dto => dto.TelefonoCliente, opt => opt.MapFrom(entity => entity.Telefono));
        }
    }
}