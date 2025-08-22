using AutoMapper;
using INCHE.Application.Database.Transaction.Dto.Create;
using INCHE.Application.Database.Transaction.Dto.Response;
using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Transaction.Command.Create
{
    public class CreateTransactionCommand : ICreateTransactionCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public CreateTransactionCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseTransactionDTO> Execute(CreateTransactionDTO create)
        {
            try
            {

                var account = await _db.Cuenta
                    .Include(a => a.Movimientos)
                    .FirstOrDefaultAsync(a => a.NumeroCuenta == create.Numero_Cuenta);

                if (account == null)
                    throw new ApplicationException(Messages.RecordNotFound);

                TransactionEntity trans = _mapper.Map<TransactionEntity>(create);

                await _db.Movimiento.AddAsync(trans);
                await _db.SaveAsync();

                return _mapper.Map<ResponseTransactionDTO>(trans);
            }
            catch (Exception ex) 
            {
              
                throw new ApplicationException(Messages.RecordCreationFailed, ex);
            }
        }
    }
}
