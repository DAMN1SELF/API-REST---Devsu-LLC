using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Client.Command.Delete
{
    public class DeleteClientCommand : IDeleteClientCommand
    {
        private readonly IDataBaseService _db;

        public DeleteClientCommand(IDataBaseService db)
        {
            _db = db;
        }

        public async Task<bool> Execute(int id)
        {
            try
            {
                var persona = await _db.Persona.FindAsync(id);
                if (persona is null)
                    throw new ApplicationException(Messages.RecordNotFound);

                var tieneCuentas = await _db.Cuenta.AnyAsync(cta => cta.ClienteId == id);
                if (tieneCuentas)
                    throw new ApplicationException(Messages.ClientHasLinkedAccounts);

                _db.Persona.Remove(persona);
                return await _db.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordDeletedFailed, ex);
            }
        }
    }
}