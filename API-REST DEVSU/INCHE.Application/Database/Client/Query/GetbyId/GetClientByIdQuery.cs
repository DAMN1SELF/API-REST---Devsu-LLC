using AutoMapper;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Client.Query.GetbyId
{
    public class GetClientByIdQuery : IGetClientByIdQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public GetClientByIdQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db; 
            _mapper = mapper;
        }

        public async Task<ResponseClientDTO> Execute(int id)
        {
            var dto = await _db.Cliente
                .AsNoTracking()
                .Where(e => e.PersonaId == id)
                .ProjectTo<ResponseClientDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (dto is null)
                throw new ApplicationException(Messages.RecordNotFound);

            return dto;
        }
    }
}