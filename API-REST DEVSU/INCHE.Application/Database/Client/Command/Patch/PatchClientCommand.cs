using AutoMapper;
using INCHE.Application.DataBase;
using INCHE.Application.Database.Client.Dto.Patch;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Common.Constants;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace INCHE.Application.Database.Client.Command.Patch
{
    public class PatchClientCommand : IPatchClientCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public PatchClientCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db; _mapper = mapper;
        }

        public async Task<ResponseClientDTO> Execute(int id, PatchClientDTO patch)
        {
            if (patch.CodigoCliente != id)
                throw new ApplicationException(Messages.RouteIdDoesNotMatchBodyId);

            var entity = await _db.Cliente.FirstOrDefaultAsync(c => c.PersonaId == id);
            if (entity is null) throw new ApplicationException(Messages.RecordNotFound);

            try
            {
                if (!string.IsNullOrWhiteSpace(patch.IdentificacionCliente) &&
                    patch.IdentificacionCliente != entity.Identificacion)
                {
                    var dup = await _db.Cliente.AnyAsync(c =>
                        c.PersonaId != id && c.Identificacion == patch.IdentificacionCliente);
                    if (dup) throw new ApplicationException(Messages.DuplicateKey);
                }

                _mapper.Map(patch, entity);

                await _db.SaveAsync();
                return _mapper.Map<ResponseClientDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordPatchFailed, ex);
            }
        }
    }
}