using AutoMapper;
using AutoMapper.QueryableExtensions;
using INCHE.Application.Database.Transaction.Dto.Response;
using INCHE.Application.DataBase;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Transaction.Query.GetAll
{
    public class GetTransactionsByAccountQuery : IGetTransactionsByAccountQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        public GetTransactionsByAccountQuery(IDataBaseService db, IMapper mapper)
        { 
            _db = db; 
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ResponseTransactionDTO>> Execute(Guid numeroCuenta)
        {
            return await _db.Movimiento
                .AsNoTracking()
                .Where(m => m.NumeroCuenta == numeroCuenta)
                .OrderByDescending(m => m.Fecha)
                .ProjectTo<ResponseTransactionDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
