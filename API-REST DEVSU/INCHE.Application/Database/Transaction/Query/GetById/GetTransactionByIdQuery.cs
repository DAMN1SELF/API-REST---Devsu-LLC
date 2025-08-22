using AutoMapper;
using AutoMapper.QueryableExtensions;
using INCHE.Application.Database.Transaction.Dto.Response;
using INCHE.Application.Database.Transaction.Query.GetbyId;
using INCHE.Application.DataBase;
using INCHE.Application.Database.Client.Dto.Response;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Transaction.Query.GetById
{
    public class GetTransactionByIdQuery : IGetTransactionByIdQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        public GetTransactionByIdQuery(IDataBaseService db, IMapper mapper)
        { _db = db; _mapper = mapper; }

        public async Task<ResponseTransactionDTO?> Execute(int id)
        {

            return await _db.Movimiento
                .AsNoTracking()
                .Where(e => e.MovimientoId == id)
                .ProjectTo<ResponseTransactionDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
