using AutoMapper;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Application.Database.Client.Dto.Update;
using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Client.Command.Update
{
    public class UpdateClientCommand : IUpdateClientCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public UpdateClientCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db; _mapper = mapper;
        }

        public async Task<ResponseClientDTO> Execute(int id, UpdateClientDTO update)
        {

            var entity = await _db.Cliente
                .Include(c => c.Persona)
                .FirstOrDefaultAsync(e => e.ClienteId == id);
            if (entity is null) throw new ApplicationException(Messages.RecordNotFound);

            try
            {

                if (!string.IsNullOrWhiteSpace(update.IdentificacionCliente) &&
                    update.IdentificacionCliente != entity.Persona.Identificacion)
                {
                    var dup = await _db.Cliente.AnyAsync(e => e.ClienteId != id && e.Persona.Identificacion == update.IdentificacionCliente);
                    if (dup) throw new ApplicationException(Messages.DuplicateKey);
                }

                _mapper.Map(update, entity);

                await _db.SaveAsync();
                return _mapper.Map<ResponseClientDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordUpdateFailed, ex);
            }
        }
    }
}