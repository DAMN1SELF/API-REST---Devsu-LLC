using AutoMapper;
using INCHE.Application.Database.Account.Dto.Response;
using AutoMapper.QueryableExtensions;
using INCHE.Application.DataBase;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Account.Query.GetbyNumberAccount
{
    public class GetAccountByNumberQuery : IGetAccountByNumberQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public GetAccountByNumberQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseAccountDTO?> Execute(Guid numeroCuenta)
        {

            var cuenta = await _db.Cuenta
                .AsNoTracking()
                .Where(a => a.NumeroCuenta.Equals(numeroCuenta))
                .ProjectTo<ResponseAccountDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            return cuenta;
        }
    }
}