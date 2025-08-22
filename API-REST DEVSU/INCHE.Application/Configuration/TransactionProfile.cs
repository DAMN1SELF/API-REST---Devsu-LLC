using AutoMapper;
using INCHE.Domain.Entities;
using INCHE.Application.Database.Transaction.Dto.Response;
using INCHE.Application.Database.Transaction.Dto.Create;

namespace INCHE.Application.Configuration
{
    public sealed class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            // Dto -> Entity
            CreateMap<CreateTransactionDTO, TransactionEntity>()
                .ConstructUsing(static dto =>
                    TransactionEntity.RegistrarMovimiento(dto.Numero_Cuenta, (TransactionType)dto.Tipo_Movimiento,
                        dto.Valor_Movimiento)
                );
            //    .ForMember(d => d.Cuenta, opt => opt.Ignore());


            // Entity -> ResponseDTO

            CreateMap<TransactionEntity, ResponseTransactionDTO>()
                .ForMember(dto => dto.Fecha_Movimiento, opt => opt.MapFrom(entity => entity.Fecha))
                .ForMember(dto => dto.Movimiento_Id, opt => opt.MapFrom(entity => entity.MovimientoId))
                .ForMember(dto => dto.Tipo_Movimiento, opt => opt.MapFrom(entity => entity.TipoMovimiento))
                .ForMember(dto => dto.Saldo_Disponible, opt => opt.MapFrom(entity => entity.SaldoDisponible))
                .ForMember(dto => dto.Valor_Movimiento, opt => opt.MapFrom(entity => entity.Valor))
                .ForMember(dto => dto.Numero_Cuenta, opt => opt.MapFrom(entity => entity.NumeroCuenta));


        }
    }
}
