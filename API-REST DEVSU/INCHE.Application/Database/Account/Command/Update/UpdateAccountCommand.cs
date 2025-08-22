using AutoMapper;
using INCHE.Application.Database.Account.Dto.Response;
using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Account.Command.Update
{
    public class UpdateAccountCommand : IUpdateAccountCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public UpdateAccountCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseAccountDTO> Execute(Guid nroCuenta, bool activar)
        {
            var entity = await _db.Cuenta.FirstOrDefaultAsync(c => c.NumeroCuenta.Equals(nroCuenta) );
            if (entity is null) throw new ApplicationException(Messages.RecordNotFound);

            try
            {

                if (activar)
                {
                    entity.ActivarCuenta();
                } else if (!activar)
                {
                    if (!entity.Estado) throw new ApplicationException(Messages.RecordDesactivated);
                    entity.CerrarCuenta();
                }

                await _db.SaveAsync();
                return _mapper.Map<ResponseAccountDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordUpdateFailed, ex);
            }
        }
    }
}