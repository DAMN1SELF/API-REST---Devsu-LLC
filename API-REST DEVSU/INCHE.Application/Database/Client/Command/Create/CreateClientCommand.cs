using AutoMapper;
using INCHE.Application.Database.Client.Dto.Response;
using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using INCHE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INCHE.Application.Database.Client.Dto.Create;

namespace INCHE.Application.Database.Client.Command.Create
{
    public class CreateClientCommand : ICreateClientCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public CreateClientCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db; 
            _mapper = mapper;
        }

        public async Task<ResponseClientDTO> Execute(CreateClientDTO create)
        {
            try
             {
                if (!string.IsNullOrWhiteSpace(create.IdentificacionCliente))
                {
                    var dup = await _db.Cliente.AnyAsync(c => c.Persona.Identificacion == create.IdentificacionCliente);
                    if (dup) throw new ApplicationException(Messages.DuplicateId);
                }

                var entity = _mapper.Map<ClientEntity>(create);

                await _db.Cliente.AddAsync(entity);
                await _db.SaveAsync();

                return _mapper.Map<ResponseClientDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordCreationFailed, ex);
            }
        }
    }
}