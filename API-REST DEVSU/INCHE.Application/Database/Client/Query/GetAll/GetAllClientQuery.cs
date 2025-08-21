using AutoMapper;
using AutoMapper.QueryableExtensions;
using INCHE.Application.DataBase;
using INCHE.Application.Database.Client.Dto.Response;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Client.Query.GetAll
{
    public class GetAllClientQuery : IGetAllClientQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public GetAllClientQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db; _mapper = mapper;
        }

        public async Task<IReadOnlyList<ResponseClientDTO>> Execute()
        {

            return await _db.Cliente
                .AsNoTracking()
                .ProjectTo<ResponseClientDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}