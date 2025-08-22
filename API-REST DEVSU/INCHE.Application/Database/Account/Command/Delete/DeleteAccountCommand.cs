using INCHE.Application.DataBase;
using INCHE.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Account.Command.Delete
{
    public class DeleteAccountCommand : IDeleteAccountCommand
    {
        private readonly IDataBaseService _db;

        public DeleteAccountCommand(IDataBaseService db)
        {
            _db = db;
        }

        public async Task<bool> Execute(Guid numeroCuenta)
        {
            try
            {
                if (numeroCuenta == Guid.Empty)
                    throw new ApplicationException(Messages.InvalidKey);


                var account = await _db.Cuenta
                    .Include(a => a.Movimientos)
                    .FirstOrDefaultAsync(a => a.NumeroCuenta == numeroCuenta);

                if (account is null)
                    throw new ApplicationException(Messages.RecordNotFound);

                if (account.Movimientos is not null && account.Movimientos.Count > 0)
                    throw new ApplicationException(Messages.AccountHasLinkedMovements);

                _db.Cuenta.Remove(account);
                var saved = await _db.SaveAsync();

                return saved;
            }
            catch (Exception ex) when (!(ex is ApplicationException))
            {
          
                throw new ApplicationException(Messages.RecordDeletedFailed , ex);
            }
        }
    }
}

