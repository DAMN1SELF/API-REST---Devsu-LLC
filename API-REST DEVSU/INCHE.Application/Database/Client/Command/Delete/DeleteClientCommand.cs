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
                var entity = await _db.Cliente.FirstOrDefaultAsync(c => c.PersonaId == id);
                if (entity is null) throw new ApplicationException(Messages.RecordNotFound);


                var tieneCuentas = await _db.Cuenta.AnyAsync(cta => cta.ClienteId == id);
                if (tieneCuentas)
                    throw new ApplicationException(Messages.ClientHasLinkedAccounts);

                _db.Cliente.Remove(entity);
                return await _db.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Messages.RecordDeletedFailed, ex);
            }
        }
    }
}