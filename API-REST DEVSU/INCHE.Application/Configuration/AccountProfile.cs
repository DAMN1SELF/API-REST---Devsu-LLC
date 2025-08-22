using AutoMapper;
using INCHE.Application.Database.Account.Dto.Create;
using INCHE.Application.Database.Account.Dto.Response;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Domain.Entities;
namespace INCHE.Application.Configuration
{

    public sealed class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Dto -> Entity
            CreateMap<CreateAccountDTO, AccountEntity>()
                .ConstructUsing(static dto =>
                    AccountEntity.AperturarCuenta(dto.Cliente_Id, (AccountType)dto.Tipo_Cuenta, dto.Saldo_Inicial)
                )
                .ForMember(d => d.Movimientos, opt => opt.Ignore());

            // Entity -> ResponseDTO
            CreateMap<AccountEntity, ResponseAccountDTO>()
                .ForMember(dto => dto.Numero_Cuenta, opt => opt.MapFrom(entity => entity.NumeroCuenta))
                .ForMember(dto => dto.Cliente_Id, opt => opt.MapFrom(entity => entity.ClienteId))
                .ForMember(dto => dto.Tipo_Cuenta, opt => opt.MapFrom(entity => entity.TipoCuenta))
                .ForMember(dto => dto.Saldo_Inicial, opt => opt.MapFrom(entity => entity.SaldoInicial))
                .ForMember(dto => dto.Saldo_Actual, opt => opt.MapFrom(entity => entity.SaldoActual))
                .ForMember(dto => dto.Estado_Cuenta, opt => opt.MapFrom(entity => entity.Estado))
                .ForMember(dto => dto.Fecha_Apertura, opt => opt.MapFrom(entity => entity.FechaApertura));
        }
    }
}