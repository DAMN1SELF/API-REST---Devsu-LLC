

namespace INCHE.Application.Database.Transaction.Command.Delete
{
    public interface IDeleteTransactionCommand
    {
        Task<bool> Execute(int id);
    }
}
