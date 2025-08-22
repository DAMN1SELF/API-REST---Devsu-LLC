using AutoMapper;
using INCHE.Application.Database.Account.Dto.Create;
using INCHE.Application.Database.Account.Dto.Response;
using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using INCHE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace INCHE.Application.Database.Account.Command.Create
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;

        public CreateAccountCommand(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseAccountDTO> Execute(CreateAccountDTO create)
        {
            try
            {

                var clientExists = await _db.Persona.AnyAsync(p => p.PersonaId == create.Cliente_Id);
                if (!clientExists) throw new ApplicationException(Messages.RecordNotFound);

                AccountEntity  acc = _mapper.Map<AccountEntity>(create);

                await _db.Cuenta.AddAsync(acc);
                await _db.SaveAsync();

                return _mapper.Map<ResponseAccountDTO>(acc);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordCreationFailed, ex);
            }
        }
    }
}