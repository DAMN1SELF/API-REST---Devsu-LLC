using AutoMapper;
using INCHE.Application.Database.Account.Dto.Response;
using INCHE.Application.DataBase;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Account.Query.GetbyIdClient
{
    public class GetAccountsByClientQuery : IGetAccountsByClientQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public GetAccountsByClientQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ResponseAccountDTO>> Execute(int CodigoCliente)
        {

            var listCuentas = await _db.Cuenta
                .AsNoTracking()
                .Where(a => a.ClienteId == CodigoCliente)
                .ProjectTo<ResponseAccountDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return listCuentas;
        }
    }
}