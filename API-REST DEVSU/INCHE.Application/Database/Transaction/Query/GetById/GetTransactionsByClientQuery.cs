
using AutoMapper;
using AutoMapper.QueryableExtensions;
using INCHE.Application.DataBase;
using INCHE.Application.Database.Transaction.Dto.Response;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Transaction.Query.GetById
{
 
    public class GetTransactionsByClientQuery : IGetTransactionsByClientQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        public GetTransactionsByClientQuery(IDataBaseService db, IMapper mapper)
        { 
            _db = db; 
            _mapper = mapper;

        }

        public async Task<IReadOnlyList<ResponseTransactionDTO>> Execute(int clienteId)
        {
      
            return await _db.Movimiento
                .AsNoTracking()
                .Where(m => m.Cuenta != null && m.Cuenta.ClienteId == clienteId)
                .OrderByDescending(m => m.Fecha)
                .ProjectTo<ResponseTransactionDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
