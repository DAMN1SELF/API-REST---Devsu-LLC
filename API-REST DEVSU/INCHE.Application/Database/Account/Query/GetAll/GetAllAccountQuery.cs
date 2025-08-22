

using AutoMapper;
using AutoMapper.QueryableExtensions;
using INCHE.Application.DataBase;
using INCHE.Application.Database.Account.Dto.Response;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Application.Database.Client.Query.GetAll;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Account.Query.GetAll
{

    public class GetAllAccountQuery : IGetAllAccountQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public GetAllAccountQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db; _mapper = mapper;
        }

        public async Task<IReadOnlyList<ResponseAccountDTO>> Execute()
        {

            return await _db.Cuenta
                .AsNoTracking()
                .ProjectTo<ResponseAccountDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
