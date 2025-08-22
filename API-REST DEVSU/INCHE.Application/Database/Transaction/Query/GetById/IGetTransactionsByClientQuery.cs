using INCHE.Application.Database.Transaction.Dto.Response;

namespace INCHE.Application.Database.Transaction.Query.GetById
{
    public interface IGetTransactionsByClientQuery
    {
        Task<IReadOnlyList<ResponseTransactionDTO>> Execute(int clienteId);
    }
}
