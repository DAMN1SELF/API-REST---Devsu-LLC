using INCHE.Application.DataBase;
using Microsoft.EntityFrameworkCore;

namespace INCHE.Application.Database.Transaction.Command.Delete
{
    public class DeleteTransactionCommand : IDeleteTransactionCommand
    {
        private readonly IDataBaseService _db;
        public DeleteTransactionCommand(IDataBaseService db) => _db = db;

        public async Task<bool> Execute(int id)
        {
            var entity = await _db.Movimiento.FirstOrDefaultAsync(m => m.MovimientoId == id);
            if (entity == null) return false;

            _db.Movimiento.Remove(entity);

            await _db.SaveAsync();
            return true;
        }
    }
}
